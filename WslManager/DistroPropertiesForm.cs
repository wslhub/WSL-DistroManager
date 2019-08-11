using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using WslManager.Helpers;
using WslManager.Shared;

namespace WslManager
{
    public partial class DistroPropertiesForm : Form
    {
        public DistroPropertiesForm()
        {
            InitializeComponent();
        }

        public WslQueryDistroModel Model { get; set; }

        private void DistroPropertiesForm_Load(object sender, EventArgs e)
        {
            var model = Model;

            if (model == null)
                return;

            DistroNameText.Text = model.DistroName;
            DistroIcon.Image = ImageList.Images[SharedRoutines.GetImageKey(model.DistroName)];
            DistroLocation.Text = model.BasePath;
            State.Text = model.DistroName;
            IsDefaultDistro.Text = model.IsDefaultDistro ? "Yes" : "No";
            WSLVersion.Text = model.WslVersion.ToString();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Append NT Path", (model.AppendNtPath ? "Yes" : "No"));
            dictionary.Add("Enable Drive Mounting", (model.EnableDriveMounting ? "Yes" : "No"));
            dictionary.Add("Enable Interop", (model.EnableInterop ? "Yes" : "No"));
            dictionary.Add("Kernel Command Line", model.KernelCommandLine);
            dictionary.Add("Default Environment Variables", model.DefaultEnvironment);
            dictionary.Add("Default User ID", model.DefaultUid.ToString());
            dictionary.Add("Distro Unique ID", model.DistroId);

            DistroPropertyGrid.SelectedObject = new DictionaryPropertyGridAdapter(dictionary);

            var ext4VhdxPath = Path.Combine(
                Path.GetFullPath(model.BasePath),
                "ext4.vhdx");

            if (model.WslVersion < 2 || !File.Exists(ext4VhdxPath))
                DistroSizeCalculator.RunWorkerAsync(DistroLocation.Text);
            else
                DistroSize.Text = $"{(new FileInfo(ext4VhdxPath).Length / 1024 / 1024)} MiB";

            Text = $"{model.DistroName} Properties";
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
