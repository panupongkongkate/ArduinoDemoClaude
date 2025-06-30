using System;
using System.Drawing;
using System.Windows.Forms;
using Arduino.Services;

namespace Arduino.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authService;
        
        public LoginForm(AuthenticationService authService)
        {
            _authService = authService;
            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            buttonLogin.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var (success, message) = await _authService.LoginAsync(
                    textBoxUsername.Text, 
                    textBoxPassword.Text
                );

                if (success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(message, "Login Failed", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxPassword.Clear();
                    textBoxPassword.Focus();
                }
            }
            finally
            {
                buttonLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonLogin_Click(sender, e);
                e.Handled = true;
            }
        }
        
        // Fast Login สำหรับ Admin
        private void buttonFastAdmin_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "admin";
            textBoxPassword.Text = "admin123";
            buttonLogin_Click(sender, e);
        }
        
        // Fast Login สำหรับ User
        private void buttonFastUser_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "user";
            textBoxPassword.Text = "user123";
            buttonLogin_Click(sender, e);
        }
        
        // Fast Login สำหรับ Viewer
        private void buttonFastViewer_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = "viewer";
            textBoxPassword.Text = "viewer123";
            buttonLogin_Click(sender, e);
        }
    }
}