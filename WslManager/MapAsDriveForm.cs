using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using WslManager.Interop;
using WslManager.Structures;

namespace WslManager
{
    public partial class MapAsDriveForm : Form
    {
        public MapAsDriveForm()
        {
            InitializeComponent();
        }

        public string SelectedDistro { get; set; }

        private MappedDriveQueryResultModel latestQueryResult;

        private void DataSourceRefresher_DoWork(object sender, DoWorkEventArgs e)
        {
            var wslMappings = new Dictionary<string, string>();
            using (var searcher = new ManagementObjectSearcher(
                @"root\CIMV2",
                @"SELECT * FROM Win32_MappedLogicalDisk"))
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    var path = Convert.ToString(queryObj["ProviderName"]);
                    var isWsl = path.StartsWith(@"\\wsl$\");
                    if (!isWsl) continue;

                    var distroName = Path.GetFileName(path);
                    var driveLetter = Convert.ToString(queryObj["Name"]);
                    wslMappings.Add(driveLetter, distroName);
                }
            }

            foreach (var eachLetter in Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => $"{(char)x}:").ToArray())
            {
                var driveInfo = new DriveInfo(eachLetter);

                if (driveInfo.DriveType == DriveType.NoRootDirectory)
                {
                    wslMappings.Add(eachLetter, string.Empty);
                    continue;
                }
            }

            wslMappings = wslMappings.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            var items = SharedRoutines.LoadDistroList().ToArray();
            e.Result = new MappedDriveQueryResultModel()
            {
                AvailableDrives = new WslMappedDriveInfoCollection(wslMappings.Select(x => new WslMappedDriveInfo() { DriveName = x.Key, DistroName = x.Value })),
                WslDistroList = items.Select(x => x.DistroName).ToArray(),
            };
        }

        private void MapAsDriveForm_Load(object sender, EventArgs e)
        {
            DataSourceRefresher.RunWorkerAsync();
        }

        private void DataSourceRefresher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                RefreshStatusLabel.Text = "Data refresh task cancelled.";
                return;
            }

            if (e.Error != null)
            {
                RefreshStatusLabel.Text = $"Data refresh task halted due to error - {e.Error.Message}";
                return;
            }

            var result = e.Result as MappedDriveQueryResultModel;
            if (result == null)
            {
                RefreshStatusLabel.Text = $"Data refresh task halted due to error - invalid data type found.";
                return;
            }

            latestQueryResult = result;

            DriveLetter.DataSource = latestQueryResult.AvailableDrives.ToArray();

            if (!string.IsNullOrWhiteSpace(SelectedDistro))
            {
                var foundAvailableDrive = latestQueryResult.AvailableDrives.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.DistroName));

                if (foundAvailableDrive == null)
                {
                    MessageBox.Show(this, "No drive letters available.", Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    DriveLetter.SelectedItem = foundAvailableDrive;
                }
            }

            TargetDistro.DataSource = latestQueryResult.WslDistroList;
            TargetDistro.SelectedItem = SelectedDistro;
            RefreshStatusLabel.Text = "Ready";
        }

        private void MapAsDriveForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var item = TargetDistro.SelectedItem as string;
    
            if (item != null)
                SelectedDistro = item;
        }

        private void DriveLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = DriveLetter.SelectedItem as WslMappedDriveInfo;

            if (item != null && !string.IsNullOrWhiteSpace(item.DistroName))
            {
                MapDriveButton.Enabled = false;
                UnmapDriveButton.Enabled = true;
                TargetDistro.Enabled = false;
            }
            else
            {
                MapDriveButton.Enabled = true;
                UnmapDriveButton.Enabled = false;
                TargetDistro.Enabled = true;
            }
        }

        private void MapDriveButton_Click(object sender, EventArgs e)
        {
            var selectedDrive = DriveLetter.SelectedItem as WslMappedDriveInfo;

            if (selectedDrive == null)
                return;

            var targetDistro = TargetDistro.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(targetDistro))
                return;

            Process.Start(new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $@"-d {targetDistro} -- exit")
            {
                UseShellExecute = false,
                WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                CreateNoWindow = true,
            }).WaitForExit();

            var parameters = new NativeMethods.NetworkResource()
            {
                iScope = 2,
                iType = NativeMethods.RESOURCETYPE_DISK,
                iDisplayType = 3,
                iUsage = 1,
                sRemoteName = $@"\\wsl$\{TargetDistro.SelectedItem}",
                sLocalName = selectedDrive.DriveName,
            };

            var flags = 0;

            if (PersistentConnection.Checked)
                flags += NativeMethods.CONNECT_UPDATE_PROFILE;

            var resultCode = NativeMethods.WNetAddConnection2W(ref parameters, null, null, flags);

            if (resultCode > 0)
            {
                var message = new Win32Exception(resultCode).Message;
                MessageBox.Show(this, message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Process.Start(new ProcessStartInfo(selectedDrive.DriveName) { UseShellExecute = true, });
            }

            DataSourceRefresher.RunWorkerAsync();
        }

        private void UnmapDriveButton_Click(object sender, EventArgs e)
        {
            var selectedDrive = DriveLetter.SelectedItem as WslMappedDriveInfo;

            if (selectedDrive == null)
                return;

            int flags = 0;

            if (PersistentConnection.Checked)
                flags += NativeMethods.CONNECT_UPDATE_PROFILE;

            var resultCode = NativeMethods.WNetCancelConnection2W(selectedDrive.DriveName, flags, Convert.ToInt32(false));

            if (resultCode > 0)
            {
                var message = new Win32Exception(resultCode).Message;
                MessageBox.Show(this, message, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            DataSourceRefresher.RunWorkerAsync();
        }
    }
}
