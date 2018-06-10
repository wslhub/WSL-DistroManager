using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace DistroManager
{
    public partial class MainForm : Form
    {
        public MainForm() : base()
        {
            this.InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!Helpers.IsAdministrator())
            {
                NativeMethods.SendMessage(cloneButton.Handle, NativeMethods.BCM_SETSHIELD, 0, 1);
                NativeMethods.SendMessage(setDefaultButton.Handle, NativeMethods.BCM_SETSHIELD, 0, 1);
                NativeMethods.SendMessage(removeButton.Handle, NativeMethods.BCM_SETSHIELD, 0, 1);
            }

            this.refreshButton.PerformClick();
        }

        private void distroInfoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            this.propertyGrid.SelectedObject = this.distroInfoBindingSource.Current;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            var distroList = new List<DistroInfo>();
            distroList.Clear();

            using (var lxssKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Lxss", false))
            {
                foreach (var eachSubKeyName in lxssKey.GetSubKeyNames())
                {
                    using (var lxssSubKey = lxssKey.OpenSubKey(eachSubKeyName, false))
                    {
                        string basePath = lxssSubKey.GetValue("BasePath", null) as string;
                        var defaultEnvironment = Helpers.ParseEnvironmentVariables(lxssSubKey.GetValue("DefaultEnvironment", new string[] { }) as string[]);
                        int defaultUid = (int)lxssSubKey.GetValue("DefaultUid", NativeMethods.UID_INVALID);
                        string distributionName = lxssSubKey.GetValue("DistributionName", null) as string;
                        int flags = (int)lxssSubKey.GetValue("Flags", NativeMethods.WSL_DISTRIBUTION_FLAGS.WSL_DISTRIBUTION_FLAGS_NONE);
                        string kernelCommandLine = lxssSubKey.GetValue("KernelCommandLine", null) as string;
                        int state = (int)lxssSubKey.GetValue("State", 0);
                        int version = (int)lxssSubKey.GetValue("Version", 0);

                        distroList.Add(new DistroInfo
                        {
                            BasePath = basePath,
                            DefaultEnvironment = defaultEnvironment,
                            DefaultUid = defaultUid,
                            DistributionName = distributionName,
                            Flags = flags,
                            KernelCommandLine = kernelCommandLine,
                            State = state,
                            Version = version
                        });
                    }
                }
            }

            this.distroInfoBindingSource.DataSource = distroList;
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            var distroInfo = this.distroInfoBindingSource.Current as DistroInfo;

            if (distroInfo == null)
                return;
            
            if (this.createBackupDialog.ShowDialog(this) != DialogResult.OK)
                return;

            string backupFilePath = Path.GetFullPath(createBackupDialog.FileName);
            string translatedPath = "/mnt/" + Regex.Replace(
	            backupFilePath,
	            @"(?<DriveLetter>[a-zA-Z])\:\\",
	            m => m.Groups["DriveLetter"].Value.ToLowerInvariant() + "/")
	            .Replace('\\', '/');

            using (var distro = new Distro(distroInfo.DistributionName))
            {
                int hr = distro.LaunchInteractive("cd / && " +
                    "sudo tar -cvpzf /backup.tar.gz --exclude=/backup.tar.gz --one-file-system / && " +
                    $"sudo mv /backup.tar.gz {translatedPath}",
                    false, out int exitCode);

                if (NativeMethods.FAILED(hr))
                {
                    MessageBox.Show(this,
                        $"WslLaunchInteractive failed - HRESULT: 0x{hr:X8}, Reason: {new Win32Exception(hr).Message}",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (exitCode != 0)
                {
                    MessageBox.Show(this,
                        $"Backup procedure failed. Exit Code: {exitCode}",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (!File.Exists(backupFilePath))
                {
                    MessageBox.Show(this,
                        $"Backup file does not created at `{backupFilePath}`.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                Process.Start(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"),
                    String.Format(CultureInfo.InvariantCulture, "/select,\"{0}\"", backupFilePath));
            }
        }

        private void setDefaultButton_Click(object sender, EventArgs e)
        {
            var distroInfo = this.distroInfoBindingSource.Current as DistroInfo;

            if (distroInfo == null)
                return;

            var wslConfigPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                "wslconfig.exe");

            if (!File.Exists(wslConfigPath))
            {
                MessageBox.Show(this,
                    $"The `wslconfig.exe` is missing. Please check WSL installed properly.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            var psi = new ProcessStartInfo(wslConfigPath, $"/s {distroInfo.DistributionName}");
            psi.Verb = "runas";
            Process.Start(psi);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var distroInfo = this.distroInfoBindingSource.Current as DistroInfo;

            if (distroInfo == null)
                return;

            var wslConfigPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                "wslconfig.exe");

            if (!File.Exists(wslConfigPath))
            {
                MessageBox.Show(this,
                    $"The `wslconfig.exe` is missing. Please check WSL installed properly.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            var psi = new ProcessStartInfo(wslConfigPath, $"/u {distroInfo.DistributionName}");
            psi.Verb = "runas";
            Process.Start(psi);
        }

        private void cloneButton_Click(object sender, EventArgs e)
        {
            var distroInfo = this.distroInfoBindingSource.Current as DistroInfo;

            if (distroInfo == null)
                return;

            string backupFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                $@"DistroManager\Temp\{Guid.NewGuid().ToString("N")}.tar.gz");

            if (!Directory.Exists(Path.GetDirectoryName(backupFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(backupFilePath));

            string translatedPath = "/mnt/" + Regex.Replace(
	            backupFilePath,
	            @"(?<DriveLetter>[a-zA-Z])\:\\",
	            m => m.Groups["DriveLetter"].Value.ToLowerInvariant() + "/")
	            .Replace('\\', '/');

            using (var cloneDistroForm = new CloneDistroForm())
            {
                cloneDistroForm.ExistingDistroName = distroInfo.DistributionName;

                if (cloneDistroForm.ShowDialog(this) != DialogResult.OK)
                    return;

                // Backup existing distro
                using (var distro = new Distro(distroInfo.DistributionName))
                {
                    int hr = distro.LaunchInteractive("cd / && " +
                        "sudo tar -cvpzf /backup.tar.gz --exclude=/backup.tar.gz --one-file-system / && " +
                        $"sudo mv /backup.tar.gz {translatedPath}",
                        false, out int exitCode);

                    if (NativeMethods.FAILED(hr))
                    {
                        MessageBox.Show(this,
                            $"WslLaunchInteractive failed - HRESULT: 0x{hr:X8}, Reason: {new Win32Exception(hr).Message}",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (exitCode != 0)
                    {
                        MessageBox.Show(this,
                            $"Backup procedure failed. Exit Code: {exitCode}",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (!File.Exists(backupFilePath))
                    {
                        MessageBox.Show(this,
                            $"Backup file does not created at `{backupFilePath}`.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                // Install new distro
                using (var distro = new Distro(cloneDistroForm.NewDistroName))
                {
                    var newPath = Path.Combine(cloneDistroForm.DistroInstallPath, "install.tar.gz");
                    File.Move(backupFilePath, newPath);

                    var newExecPath = Path.Combine(cloneDistroForm.DistroInstallPath, cloneDistroForm.NewDistroName + ".exe");
                    var newConfPath = Path.Combine(cloneDistroForm.DistroInstallPath, cloneDistroForm.NewDistroName + ".exe.config");
                    File.Copy(Path.GetFullPath("DistroLauncher.exe"), newExecPath, true);
                    File.Copy(Path.GetFullPath("DistroLauncher.exe.config"), newConfPath, true);

                    XmlDocument document = new XmlDocument();
                    document.Load(newConfPath);
                    document.DocumentElement.SelectSingleNode("appSettings/add[@key='DistroName']/@value").Value = cloneDistroForm.NewDistroName;
                    document.DocumentElement.SelectSingleNode("appSettings/add[@key='DistroDisplayName']/@value").Value = cloneDistroForm.NewDistroName;
                    document.Save(newConfPath);

                    ProcessStartInfo psi = new ProcessStartInfo(newExecPath);
                    psi.Verb = "runas";
                    Process.Start(psi);
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var distroInfo = this.dataGridView.Rows[e.RowIndex].DataBoundItem as DistroInfo;

            if (distroInfo == null)
                return;

            using (var distro = new Distro(distroInfo.DistributionName))
            {
                int hr = distro.Launch("/bin/bash", false, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, out IntPtr process);

                if (NativeMethods.FAILED(hr))
                {
                    MessageBox.Show(this,
                        $"WslLaunchInteractive failed - HRESULT: 0x{hr:X8}, Reason: {new Win32Exception(hr).Message}",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
        }
    }
}
