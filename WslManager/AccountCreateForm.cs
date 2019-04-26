using System;
using System.Linq;
using System.Windows.Forms;

namespace WslManager
{
    public partial class AccountCreateForm : Form
    {
        public AccountCreateForm()
        {
            InitializeComponent();
        }

        public string AccountId {
            get => UserId.Text;
            set => UserId.Text = value ?? string.Empty;
        }

        public string AccountPassword {
            get => Password.Text;
            set => Password.Text = value ?? string.Empty;
        }

        public string[] UsedAccountIdList { get; set; }

        public PasswordScore ExpectedPasswordScore { get; set; }

        private void AccountCreateForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var accountIdList = UsedAccountIdList ?? new string[] { };

            if (accountIdList.Length > 0)
            {
                if (accountIdList.Contains(AccountId, StringComparer.Ordinal))
                {
                    MessageBox.Show(this,
                        "You cannot use the selected ID. Please choose another ID.",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    UserId.Focus();
                    return;
                }
            }

            var rank = Helpers.CheckStrength(AccountPassword);

            if (rank < ExpectedPasswordScore)
            {
                if (AccountPassword.Length < 1)
                {
                    MessageBox.Show(this,
                        "Please use more stronger password for your security.",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    Password.Focus();
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
