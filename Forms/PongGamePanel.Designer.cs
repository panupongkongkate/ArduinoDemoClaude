namespace Arduino.Forms
{
    partial class PongGamePanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Required designer variables.
        /// </summary>
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Timer gameTimer;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (gameTimer != null))
            {
                gameTimer.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Size = new System.Drawing.Size(850, 600);
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // Create container panel for better organization
            var headerPanel = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(850, 50),
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            this.Controls.Add(headerPanel);
            
            // Title Label
            var titleLabel = new System.Windows.Forms.Label
            {
                Text = "🎮 Pong Game - Player vs Bot",
                Location = new System.Drawing.Point(10, 10),
                Size = new System.Drawing.Size(300, 30),
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(25, 30, 40)
            };
            headerPanel.Controls.Add(titleLabel);
            
            // Score Label
            lblScore = new System.Windows.Forms.Label
            {
                Location = new System.Drawing.Point(350, 10),
                Size = new System.Drawing.Size(150, 30),
                ForeColor = System.Drawing.Color.FromArgb(25, 30, 40),
                Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Text = "0 - 0",
                BackColor = System.Drawing.Color.Transparent
            };
            headerPanel.Controls.Add(lblScore);

            // Control Panel
            var controlPanel = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(0, 520),
                Size = new System.Drawing.Size(850, 80),
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            this.Controls.Add(controlPanel);
            
            // Start Button
            btnStart = new System.Windows.Forms.Button
            {
                Location = new System.Drawing.Point(375, 25),
                Size = new System.Drawing.Size(100, 35),
                Text = "Start Game",
                BackColor = System.Drawing.Color.FromArgb(76, 175, 80),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Click += BtnStart_Click;
            controlPanel.Controls.Add(btnStart);
            
            // Instructions Label
            var instructionsLabel = new System.Windows.Forms.Label
            {
                Text = "ควบคุม: เมาส์ | W/S | ↑/↓ | ผู้เล่น: สีเขียว | Bot: สีส้ม | เป้าหมาย: 10 คะแนน",
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(550, 20),
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = System.Drawing.Color.FromArgb(100, 100, 100),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            controlPanel.Controls.Add(instructionsLabel);

            // Game Panel with border
            var gameContainer = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(75, 60),
                Size = new System.Drawing.Size(700, 450),
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240),
                Padding = new System.Windows.Forms.Padding(5)
            };
            this.Controls.Add(gameContainer);
            
            gamePanel = new System.Windows.Forms.Panel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                BackColor = System.Drawing.Color.Black,
                BorderStyle = System.Windows.Forms.BorderStyle.None
            };
            gamePanel.Paint += GamePanel_Paint;
            gameContainer.Controls.Add(gamePanel);

            // Timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += GameTimer_Tick;

            // Mouse events for player control
            gamePanel.MouseMove += GamePanel_MouseMove;
        }

        #endregion
    }
}