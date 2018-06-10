using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
