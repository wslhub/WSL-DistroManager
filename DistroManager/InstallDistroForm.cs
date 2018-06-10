using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistroManager
{
    public partial class InstallDistroForm : Form
    {
        public InstallDistroForm()
        {
            this.InitializeComponent();
        }

        public string NewDistroName
        {
            get => distroName.Text;
            set => distroName.Text = (value ?? String.Empty).Trim();
        }

        public string DistroInstallPath
        {
            get => distroInstallPath.Text;
            set => distroInstallPath.Text = (value ?? String.Empty).Trim();
        }
        
        public string InstallSourcePath
        {
            get => installSourcePath.Text;
            set => installSourcePath.Text = (value ?? String.Empty).Trim();
        }

        private void InstallDistroForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.distroInstallPath.Text))
                this.distroInstallPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var newName = (this.distroName.Text ?? String.Empty).Trim();

            if (String.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show(this, "Please specify new distro name.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.distroName.Focus();
                return;
            }

            // TODO: Check existing distro name from registry again.

            if (!Directory.Exists(this.distroInstallPath.Text))
            {
                var response = MessageBox.Show(this, "Selected directory is not existing. Create the directory now?", this.Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (response != DialogResult.Yes)
                {
                    this.distroInstallPath.Focus();
                    return;
                }
                else
                {
                    Directory.CreateDirectory(this.distroInstallPath.Text);
                }
            }

            if (!File.Exists(this.installSourcePath.Text))
            {
                MessageBox.Show(this, "Please check the install source path. Selected path is not an existing file.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.distroInstallPath.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void directoryBrowseButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(this.distroInstallPath.Text))
                this.folderBrowserDialog.SelectedPath = this.distroInstallPath.Text;

            if (this.folderBrowserDialog.ShowDialog(this) != DialogResult.OK)
                return;

            this.distroInstallPath.Text = this.folderBrowserDialog.SelectedPath;
        }

        private void browseInstallPathButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.installSourcePath.Text))
                this.openFileDialog.FileName = this.installSourcePath.Text;

            if (this.openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            this.installSourcePath.Text = this.openFileDialog.FileName;
        }
    }
}
