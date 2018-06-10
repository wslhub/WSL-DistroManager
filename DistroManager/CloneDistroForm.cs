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
    public partial class CloneDistroForm : Form
    {
        public CloneDistroForm()
        {
            this.InitializeComponent();
        }

        private string _existingDistroName = String.Empty;

        public string ExistingDistroName
        {
            get => _existingDistroName;
            set => _existingDistroName = value ?? String.Empty;
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

        public bool RemoveCurrentDefaultUser
        {
            get => removeCurrentDefaultUser.Checked;
            set => removeCurrentDefaultUser.Checked = value;
        }

        public bool RemoveLogsAndMailboxContents
        {
            get => removeLogsAndMailboxContents.Checked;
            set => removeLogsAndMailboxContents.Checked = value;
        }

        private void CloneDistroForm_Load(object sender, EventArgs e)
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
            if (String.Equals(_existingDistroName, newName, StringComparison.Ordinal))
            {
                MessageBox.Show(this, "You cannot use existing distro name.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.distroName.Focus();
                return;
            }

            if (!Directory.Exists(this.distroInstallPath.Text))
            {
                MessageBox.Show(this, "Please check the install path. Select path is not an existing directory.", this.Text,
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
    }
}
