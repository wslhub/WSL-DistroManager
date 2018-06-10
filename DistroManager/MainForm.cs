using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            var distroList = this.distroInfoBindingSource.DataSource as List<DistroInfo> ?? new List<DistroInfo>();
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

        }

        private void setDefaultButton_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        private void cloneButton_Click(object sender, EventArgs e)
        {

        }
    }
}
