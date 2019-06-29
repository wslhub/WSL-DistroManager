using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using WslManager.Helpers;

namespace WslManager
{
    public partial class DistroPropertiesForm : Form
    {
        public DistroPropertiesForm()
        {
            InitializeComponent();
        }

        public string DistroName
        {
            get => DistroNameText.Text;
            set => DistroNameText.Text = value;
        }

        private void DistroPropertiesForm_Load(object sender, EventArgs e)
        {
            using (var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Lxss"))
            {
                foreach (var eachSubKeyname in reg.GetSubKeyNames())
                {
                    using (var subReg = reg.OpenSubKey(eachSubKeyname))
                    {
                        if (string.Equals(subReg.GetValue("DistributionName", "") as string, DistroName, StringComparison.Ordinal))
                        {
                            ReadDistroProperties(subReg);
                            break;
                        }
                    }
                }
            }
        }

        private void ReadDistroProperties(RegistryKey registryKey)
        {
            if (registryKey == null)
                return;

            DistroIcon.Image = ImageList.Images[SharedRoutines.GetImageKey(DistroName)];
            DistroLocation.Text = SharedRoutines.NormalizePath((string)registryKey.GetValue("BasePath", ""));
            State.Text = "0x" + ((int)registryKey.GetValue("State", 0)).ToString("X8");
            AppxName.Text = (string)registryKey.GetValue("PackageFamilyName", "");
            WSLVersion.Text = ((int)registryKey.GetValue("Version", 0)).ToString();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("UniqueId", Path.GetFileName(registryKey.Name));

            foreach (var eachName in registryKey.GetValueNames())
                dictionary.Add(eachName, registryKey.GetValue(eachName, null));

            DistroPropertyGrid.SelectedObject = new DictionaryPropertyGridAdapter(dictionary);
            DistroSizeCalculator.RunWorkerAsync(DistroLocation.Text);
            Text = $"{DistroName} Properties";
        }

        private void DistroSizeCalculator_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = 0L;
            var targetDir = e.Argument as string;

            if (string.IsNullOrWhiteSpace(targetDir))
                return;

            if (File.Exists(targetDir))
            {
                e.Result = new FileInfo(targetDir).Length;
                return;
            }

            if (!Directory.Exists(targetDir))
                return;

            var directoryInfo = new DirectoryInfo(targetDir);
            var accLength = 0L;

            foreach (var eachEntry in directoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                if (DistroSizeCalculator.CancellationPending)
                    break;

                accLength += eachEntry.Length;

                if (accLength % 19 == 0)
                    DistroSizeCalculator.ReportProgress(50, accLength);
            }

            e.Result = accLength;
        }

        private void DistroSizeCalculator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DistroSize.Text = $"(Calculating) {(long)e.UserState / 1024 / 1024} MiB";
        }

        private void DistroSizeCalculator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DistroSize.Text = $"Unexpected Error Occurred: {e.Error.Message}";
                return;
            }

            if (e.Cancelled)
            {
                DistroSize.Text = "Size calculation cancelled.";
                return;
            }

            DistroSize.Text = $"{(long)e.Result / 1024 / 1024} MiB";
        }

        private void DistroPropertiesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DistroSizeCalculator.CancelAsync();
        }
    }
}
