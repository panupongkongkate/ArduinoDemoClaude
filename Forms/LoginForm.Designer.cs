namespace Arduino.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelFastLogin;
        private System.Windows.Forms.Label labelFastLogin;
        private System.Windows.Forms.Button buttonFastAdmin;
        private System.Windows.Forms.Button buttonFastUser;
        private System.Windows.Forms.Button buttonFastViewer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(400, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(100, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Arduino Login";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelUsername.Location = new System.Drawing.Point(50, 120);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(71, 19);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxUsername.Location = new System.Drawing.Point(50, 145);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(300, 27);
            this.textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPassword.Location = new System.Drawing.Point(50, 190);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(70, 19);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxPassword.Location = new System.Drawing.Point(50, 215);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(300, 27);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(50, 270);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(140, 40);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(210, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(140, 40);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panelFastLogin
            // 
            this.panelFastLogin = new System.Windows.Forms.Panel();
            this.labelFastLogin = new System.Windows.Forms.Label();
            this.buttonFastAdmin = new System.Windows.Forms.Button();
            this.buttonFastUser = new System.Windows.Forms.Button();
            this.buttonFastViewer = new System.Windows.Forms.Button();
            this.panelFastLogin.SuspendLayout();
            // 
            // panelFastLogin
            // 
            this.panelFastLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelFastLogin.Controls.Add(this.labelFastLogin);
            this.panelFastLogin.Controls.Add(this.buttonFastAdmin);
            this.panelFastLogin.Controls.Add(this.buttonFastUser);
            this.panelFastLogin.Controls.Add(this.buttonFastViewer);
            this.panelFastLogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFastLogin.Location = new System.Drawing.Point(0, 350);
            this.panelFastLogin.Name = "panelFastLogin";
            this.panelFastLogin.Size = new System.Drawing.Size(400, 100);
            this.panelFastLogin.TabIndex = 7;
            // 
            // labelFastLogin
            // 
            this.labelFastLogin.AutoSize = true;
            this.labelFastLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelFastLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelFastLogin.Location = new System.Drawing.Point(50, 10);
            this.labelFastLogin.Name = "labelFastLogin";
            this.labelFastLogin.Size = new System.Drawing.Size(112, 15);
            this.labelFastLogin.TabIndex = 0;
            this.labelFastLogin.Text = "Fast Login (Demo):";
            // 
            // buttonFastAdmin
            // 
            this.buttonFastAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.buttonFastAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFastAdmin.FlatAppearance.BorderSize = 0;
            this.buttonFastAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFastAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFastAdmin.ForeColor = System.Drawing.Color.White;
            this.buttonFastAdmin.Location = new System.Drawing.Point(50, 35);
            this.buttonFastAdmin.Name = "buttonFastAdmin";
            this.buttonFastAdmin.Size = new System.Drawing.Size(90, 30);
            this.buttonFastAdmin.TabIndex = 1;
            this.buttonFastAdmin.Text = "Admin";
            this.buttonFastAdmin.UseVisualStyleBackColor = false;
            this.buttonFastAdmin.Click += new System.EventHandler(this.buttonFastAdmin_Click);
            // 
            // buttonFastUser
            // 
            this.buttonFastUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.buttonFastUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFastUser.FlatAppearance.BorderSize = 0;
            this.buttonFastUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFastUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFastUser.ForeColor = System.Drawing.Color.White;
            this.buttonFastUser.Location = new System.Drawing.Point(155, 35);
            this.buttonFastUser.Name = "buttonFastUser";
            this.buttonFastUser.Size = new System.Drawing.Size(90, 30);
            this.buttonFastUser.TabIndex = 2;
            this.buttonFastUser.Text = "User";
            this.buttonFastUser.UseVisualStyleBackColor = false;
            this.buttonFastUser.Click += new System.EventHandler(this.buttonFastUser_Click);
            // 
            // buttonFastViewer
            // 
            this.buttonFastViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.buttonFastViewer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFastViewer.FlatAppearance.BorderSize = 0;
            this.buttonFastViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFastViewer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFastViewer.ForeColor = System.Drawing.Color.White;
            this.buttonFastViewer.Location = new System.Drawing.Point(260, 35);
            this.buttonFastViewer.Name = "buttonFastViewer";
            this.buttonFastViewer.Size = new System.Drawing.Size(90, 30);
            this.buttonFastViewer.TabIndex = 3;
            this.buttonFastViewer.Text = "Viewer";
            this.buttonFastViewer.UseVisualStyleBackColor = false;
            this.buttonFastViewer.Click += new System.EventHandler(this.buttonFastViewer_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFastLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Arduino Controller";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFastLogin.ResumeLayout(false);
            this.panelFastLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}