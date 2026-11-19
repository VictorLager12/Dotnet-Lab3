using System;
using System.Windows.Forms;

namespace IkiminaManager.Views
{
    public partial class LoginForm : Form
    {
        // Set only by the Close button, so it is the only way to end the application
        private bool closeRequested = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // IsNullOrWhiteSpace rejects both empty and spaces-only input
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username cannot be empty.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password cannot be empty.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            ChooseForm choose = new ChooseForm();

            // When the Choose form closes (by its X button or after Logout), show the login form again with a clean password field
            choose.FormClosed += (s, args) =>
            {
                txtPassword.Clear();
                this.Show();
                txtUsername.Focus();
            };

            // Hide (not close) the login form, because closing the main form would end the application
            this.Hide();
            choose.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            closeRequested = true;
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Blocks Alt+F4 and any other user-initiated close that did not come from the Close button
            if (!closeRequested && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}