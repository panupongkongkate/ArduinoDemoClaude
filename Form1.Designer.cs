namespace Arduino
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer connectionTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            connectionTimer = new System.Windows.Forms.Timer(components);
            panelSidebar = new Panel();
            buttonMenuPongGame = new Button();
            buttonMenuUsers = new Button();
            buttonMenuArduino = new Button();
            buttonMenuDashboard = new Button();
            panelLogo = new Panel();
            labelLogo = new Label();
            panelTopBar = new Panel();
            labelPageTitle = new Label();
            panelUserInfo = new Panel();
            buttonLogout = new Button();
            labelUserRole = new Label();
            labelUserName = new Label();
            panelContent = new Panel();
            groupBoxControl = new GroupBox();
            pictureBoxLED = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            groupBoxConnection = new GroupBox();
            label1 = new Label();
            comboBoxPorts = new ComboBox();
            buttonConnect = new Button();
            labelStatus = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelUser = new ToolStripStatusLabel();
            buttonUserManagement = new Button();
            buttonMenuPongGame = new Button();
            panelSidebar.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTopBar.SuspendLayout();
            panelUserInfo.SuspendLayout();
            panelContent.SuspendLayout();
            groupBoxControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLED).BeginInit();
            groupBoxConnection.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // connectionTimer
            // 
            connectionTimer.Interval = 5000;
            connectionTimer.Tick += connectionTimer_Tick;
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(25, 30, 40);
            panelSidebar.Controls.Add(buttonMenuPongGame);
            panelSidebar.Controls.Add(buttonMenuUsers);
            panelSidebar.Controls.Add(buttonMenuArduino);
            panelSidebar.Controls.Add(buttonMenuDashboard);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(251, 800);
            panelSidebar.TabIndex = 0;
            // 
            // buttonMenuPongGame
            // 
            buttonMenuPongGame.BackColor = Color.Transparent;
            buttonMenuPongGame.Cursor = Cursors.Hand;
            buttonMenuPongGame.Dock = DockStyle.Top;
            buttonMenuPongGame.FlatAppearance.BorderSize = 0;
            buttonMenuPongGame.FlatStyle = FlatStyle.Flat;
            buttonMenuPongGame.Font = new Font("Segoe UI", 11F);
            buttonMenuPongGame.ForeColor = Color.White;
            buttonMenuPongGame.Location = new Point(0, 294);
            buttonMenuPongGame.Margin = new Padding(3, 4, 3, 4);
            buttonMenuPongGame.Name = "buttonMenuPongGame";
            buttonMenuPongGame.Padding = new Padding(23, 0, 0, 0);
            buttonMenuPongGame.Size = new Size(251, 67);
            buttonMenuPongGame.TabIndex = 4;
            buttonMenuPongGame.Text = "🎮 Pong Game";
            buttonMenuPongGame.TextAlign = ContentAlignment.MiddleLeft;
            buttonMenuPongGame.UseVisualStyleBackColor = false;
            buttonMenuPongGame.Click += buttonMenuPongGame_Click;
            // 
            // buttonMenuUsers
            // 
            buttonMenuUsers.BackColor = Color.Transparent;
            buttonMenuUsers.Cursor = Cursors.Hand;
            buttonMenuUsers.Dock = DockStyle.Top;
            buttonMenuUsers.FlatAppearance.BorderSize = 0;
            buttonMenuUsers.FlatStyle = FlatStyle.Flat;
            buttonMenuUsers.Font = new Font("Segoe UI", 11F);
            buttonMenuUsers.ForeColor = Color.White;
            buttonMenuUsers.Location = new Point(0, 227);
            buttonMenuUsers.Margin = new Padding(3, 4, 3, 4);
            buttonMenuUsers.Name = "buttonMenuUsers";
            buttonMenuUsers.Padding = new Padding(23, 0, 0, 0);
            buttonMenuUsers.Size = new Size(251, 67);
            buttonMenuUsers.TabIndex = 3;
            buttonMenuUsers.Text = "👥 User Management";
            buttonMenuUsers.TextAlign = ContentAlignment.MiddleLeft;
            buttonMenuUsers.UseVisualStyleBackColor = false;
            buttonMenuUsers.Visible = false;
            buttonMenuUsers.Click += buttonMenuUsers_Click;
            // 
            // buttonMenuArduino
            // 
            buttonMenuArduino.BackColor = Color.Transparent;
            buttonMenuArduino.Cursor = Cursors.Hand;
            buttonMenuArduino.Dock = DockStyle.Top;
            buttonMenuArduino.FlatAppearance.BorderSize = 0;
            buttonMenuArduino.FlatStyle = FlatStyle.Flat;
            buttonMenuArduino.Font = new Font("Segoe UI", 11F);
            buttonMenuArduino.ForeColor = Color.White;
            buttonMenuArduino.Location = new Point(0, 160);
            buttonMenuArduino.Margin = new Padding(3, 4, 3, 4);
            buttonMenuArduino.Name = "buttonMenuArduino";
            buttonMenuArduino.Padding = new Padding(23, 0, 0, 0);
            buttonMenuArduino.Size = new Size(251, 67);
            buttonMenuArduino.TabIndex = 2;
            buttonMenuArduino.Text = "💡 Arduino Control";
            buttonMenuArduino.TextAlign = ContentAlignment.MiddleLeft;
            buttonMenuArduino.UseVisualStyleBackColor = false;
            buttonMenuArduino.Click += buttonMenuArduino_Click;
            // 
            // buttonMenuDashboard
            // 
            buttonMenuDashboard.BackColor = Color.FromArgb(33, 150, 243);
            buttonMenuDashboard.Cursor = Cursors.Hand;
            buttonMenuDashboard.Dock = DockStyle.Top;
            buttonMenuDashboard.FlatAppearance.BorderSize = 0;
            buttonMenuDashboard.FlatStyle = FlatStyle.Flat;
            buttonMenuDashboard.Font = new Font("Segoe UI", 11F);
            buttonMenuDashboard.ForeColor = Color.White;
            buttonMenuDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            buttonMenuDashboard.Location = new Point(0, 93);
            buttonMenuDashboard.Margin = new Padding(3, 4, 3, 4);
            buttonMenuDashboard.Name = "buttonMenuDashboard";
            buttonMenuDashboard.Padding = new Padding(23, 0, 0, 0);
            buttonMenuDashboard.Size = new Size(251, 67);
            buttonMenuDashboard.TabIndex = 1;
            buttonMenuDashboard.Text = "🏠 Dashboard";
            buttonMenuDashboard.TextAlign = ContentAlignment.MiddleLeft;
            buttonMenuDashboard.UseVisualStyleBackColor = false;
            buttonMenuDashboard.Click += buttonMenuDashboard_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(20, 25, 35);
            panelLogo.Controls.Add(labelLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 4, 3, 4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(251, 93);
            panelLogo.TabIndex = 0;
            // 
            // labelLogo
            // 
            labelLogo.AutoSize = true;
            labelLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelLogo.ForeColor = Color.White;
            labelLogo.Location = new Point(23, 27);
            labelLogo.Name = "labelLogo";
            labelLogo.Size = new Size(225, 37);
            labelLogo.TabIndex = 0;
            labelLogo.Text = "Arduino Control";
            // 
            // panelTopBar
            // 
            panelTopBar.BackColor = Color.White;
            panelTopBar.Controls.Add(labelPageTitle);
            panelTopBar.Controls.Add(panelUserInfo);
            panelTopBar.Dock = DockStyle.Top;
            panelTopBar.Location = new Point(251, 0);
            panelTopBar.Margin = new Padding(3, 4, 3, 4);
            panelTopBar.Name = "panelTopBar";
            panelTopBar.Size = new Size(892, 93);
            panelTopBar.TabIndex = 1;
            panelTopBar.Paint += panelTopBar_Paint;
            // 
            // labelPageTitle
            // 
            labelPageTitle.AutoSize = true;
            labelPageTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelPageTitle.ForeColor = Color.FromArgb(25, 30, 40);
            labelPageTitle.Location = new Point(34, 24);
            labelPageTitle.Name = "labelPageTitle";
            labelPageTitle.Size = new Size(171, 41);
            labelPageTitle.TabIndex = 0;
            labelPageTitle.Text = "Dashboard";
            // 
            // panelUserInfo
            // 
            panelUserInfo.Controls.Add(buttonLogout);
            panelUserInfo.Controls.Add(labelUserRole);
            panelUserInfo.Controls.Add(labelUserName);
            panelUserInfo.Dock = DockStyle.Right;
            panelUserInfo.Location = new Point(572, 0);
            panelUserInfo.Margin = new Padding(3, 4, 3, 4);
            panelUserInfo.Name = "panelUserInfo";
            panelUserInfo.Size = new Size(320, 93);
            panelUserInfo.TabIndex = 0;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(244, 67, 54);
            buttonLogout.Cursor = Cursors.Hand;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(206, 27);
            buttonLogout.Margin = new Padding(3, 4, 3, 4);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(91, 40);
            buttonLogout.TabIndex = 0;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // labelUserRole
            // 
            labelUserRole.AutoSize = true;
            labelUserRole.Font = new Font("Segoe UI", 9F);
            labelUserRole.ForeColor = Color.FromArgb(100, 100, 100);
            labelUserRole.Location = new Point(23, 47);
            labelUserRole.Name = "labelUserRole";
            labelUserRole.Size = new Size(39, 20);
            labelUserRole.TabIndex = 1;
            labelUserRole.Text = "Role";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelUserName.ForeColor = Color.FromArgb(25, 30, 40);
            labelUserName.Location = new Point(23, 20);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(52, 25);
            labelUserName.TabIndex = 2;
            labelUserName.Text = "User";
            labelUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 245, 245);
            panelContent.Controls.Add(groupBoxControl);
            panelContent.Controls.Add(groupBoxConnection);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(251, 93);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(34, 40, 34, 40);
            panelContent.Size = new Size(892, 683);
            panelContent.TabIndex = 2;
            // 
            // groupBoxControl
            // 
            groupBoxControl.Controls.Add(pictureBoxLED);
            groupBoxControl.Controls.Add(button1);
            groupBoxControl.Controls.Add(button2);
            groupBoxControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxControl.Location = new Point(34, 213);
            groupBoxControl.Margin = new Padding(3, 4, 3, 4);
            groupBoxControl.Name = "groupBoxControl";
            groupBoxControl.Padding = new Padding(3, 4, 3, 4);
            groupBoxControl.Size = new Size(434, 213);
            groupBoxControl.TabIndex = 1;
            groupBoxControl.TabStop = false;
            groupBoxControl.Text = "LED Control";
            // 
            // pictureBoxLED
            // 
            pictureBoxLED.Location = new Point(366, 107);
            pictureBoxLED.Margin = new Padding(3, 4, 3, 4);
            pictureBoxLED.Name = "pictureBoxLED";
            pictureBoxLED.Size = new Size(46, 53);
            pictureBoxLED.TabIndex = 2;
            pictureBoxLED.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(76, 175, 80);
            button1.Cursor = Cursors.Hand;
            button1.Enabled = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(23, 107);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(137, 80);
            button1.TabIndex = 0;
            button1.Text = "💡 ON";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(244, 67, 54);
            button2.Cursor = Cursors.Hand;
            button2.Enabled = false;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(183, 107);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(137, 80);
            button2.TabIndex = 1;
            button2.Text = "💡 OFF";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // groupBoxConnection
            // 
            groupBoxConnection.Controls.Add(label1);
            groupBoxConnection.Controls.Add(comboBoxPorts);
            groupBoxConnection.Controls.Add(buttonConnect);
            groupBoxConnection.Controls.Add(labelStatus);
            groupBoxConnection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxConnection.Location = new Point(34, 40);
            groupBoxConnection.Margin = new Padding(3, 4, 3, 4);
            groupBoxConnection.Name = "groupBoxConnection";
            groupBoxConnection.Padding = new Padding(3, 4, 3, 4);
            groupBoxConnection.Size = new Size(434, 147);
            groupBoxConnection.TabIndex = 0;
            groupBoxConnection.TabStop = false;
            groupBoxConnection.Text = "Arduino Connection";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(23, 51);
            label1.Name = "label1";
            label1.Size = new Size(89, 23);
            label1.TabIndex = 0;
            label1.Text = "COM Port:";
            // 
            // comboBoxPorts
            // 
            comboBoxPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPorts.Font = new Font("Segoe UI", 10F);
            comboBoxPorts.FormattingEnabled = true;
            comboBoxPorts.Location = new Point(114, 47);
            comboBoxPorts.Margin = new Padding(3, 4, 3, 4);
            comboBoxPorts.Name = "comboBoxPorts";
            comboBoxPorts.Size = new Size(148, 31);
            comboBoxPorts.TabIndex = 1;
            // 
            // buttonConnect
            // 
            buttonConnect.BackColor = Color.FromArgb(33, 150, 243);
            buttonConnect.Cursor = Cursors.Hand;
            buttonConnect.FlatAppearance.BorderSize = 0;
            buttonConnect.FlatStyle = FlatStyle.Flat;
            buttonConnect.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonConnect.ForeColor = Color.White;
            buttonConnect.Location = new Point(286, 44);
            buttonConnect.Margin = new Padding(3, 4, 3, 4);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(126, 40);
            buttonConnect.TabIndex = 2;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = false;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStatus.ForeColor = Color.FromArgb(244, 67, 54);
            labelStatus.Location = new Point(23, 100);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(103, 20);
            labelStatus.TabIndex = 3;
            labelStatus.Text = "Disconnected";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelUser });
            statusStrip1.Location = new Point(251, 776);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(892, 24);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            toolStripStatusLabelUser.Size = new Size(875, 18);
            toolStripStatusLabelUser.Spring = true;
            toolStripStatusLabelUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonUserManagement
            // 
            buttonUserManagement.Location = new Point(0, 0);
            buttonUserManagement.Name = "buttonUserManagement";
            buttonUserManagement.Size = new Size(75, 23);
            buttonUserManagement.TabIndex = 0;
            buttonUserManagement.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1143, 800);
            Controls.Add(panelContent);
            Controls.Add(statusStrip1);
            Controls.Add(panelTopBar);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Arduino Control System";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panelSidebar.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTopBar.ResumeLayout(false);
            panelTopBar.PerformLayout();
            panelUserInfo.ResumeLayout(false);
            panelUserInfo.PerformLayout();
            panelContent.ResumeLayout(false);
            groupBoxControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLED).EndInit();
            groupBoxConnection.ResumeLayout(false);
            groupBoxConnection.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Main Layout
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        
        // Sidebar Elements
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Button buttonMenuDashboard;
        private System.Windows.Forms.Button buttonMenuArduino;
        private System.Windows.Forms.Button buttonMenuUsers;
        private System.Windows.Forms.Button buttonMenuPongGame;
        
        // TopBar Elements
        private System.Windows.Forms.Label labelPageTitle;
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserRole;
        private System.Windows.Forms.Button buttonLogout;
        
        // Content Elements (existing)
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.GroupBox groupBoxControl;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBoxLED;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        
        // Old button
        private System.Windows.Forms.Button buttonUserManagement;
    }
}