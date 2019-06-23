using System;
using System.Linq;
using System.Windows.Forms;

namespace WslManager
{
    public partial class DistroNameRequestForm : Form
    {
        public DistroNameRequestForm()
        {
            InitializeComponent();
        }

        public string SelectedDistroName
        {
            get => DistroName.Text;
            set => DistroName.Text = value;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var distroName = DistroName.Text.Trim();

            if (string.IsNullOrWhiteSpace(distroName))
            {
                MessageBox.Show(this,
                    "Please specify a valid distro name.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }

            DistroName.Text = distroName;

            var items = SharedRoutines.LoadDistroList().ToArray();

            if (items.Where(x => string.Equals(x.Text, distroName, StringComparison.Ordinal)).Count() > 0)
            {
                MessageBox.Show(this,
                    "You can not specify a distro name that is already in use. Please specify new one.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
