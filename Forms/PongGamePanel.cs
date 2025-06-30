using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arduino.Forms
{
    public partial class PongGamePanel : UserControl
    {
        // Game objects
        private Rectangle playerPaddle, botPaddle, ball;
        private int ballSpeedX = 5, ballSpeedY = 5;
        private int playerScore = 0, botScore = 0;
        private bool gameRunning = false;
        private Random random = new Random();
        
        // Bot AI
        private int botSpeed = 6;
        

        public PongGamePanel()
        {
            InitializeComponent();
            InitializeGame();
        }


        private void InitializeGame()
        {
            // Initialize paddles
            playerPaddle = new Rectangle(10, 170, 10, 80);
            botPaddle = new Rectangle(680, 170, 10, 80);
            
            // Initialize ball
            ball = new Rectangle(345, 205, 10, 10);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!gameRunning)
            {
                gameRunning = true;
                btnStart.Text = "Stop Game";
                btnStart.BackColor = Color.FromArgb(244, 67, 54);
                gameTimer.Start();
            }
            else
            {
                gameRunning = false;
                btnStart.Text = "Start Game";
                btnStart.BackColor = Color.FromArgb(76, 175, 80);
                gameTimer.Stop();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Move ball
            ball.X += ballSpeedX;
            ball.Y += ballSpeedY;

            // Ball collision with top and bottom walls
            if (ball.Y <= 0 || ball.Y >= gamePanel.Height - ball.Height)
            {
                ballSpeedY = -ballSpeedY;
            }

            // Ball collision with paddles
            if (ball.IntersectsWith(playerPaddle) || ball.IntersectsWith(botPaddle))
            {
                ballSpeedX = -ballSpeedX;
                // Add some randomness to ball speed
                ballSpeedY += random.Next(-2, 3);
                ballSpeedY = Math.Max(-8, Math.Min(8, ballSpeedY));
            }
            
            // Bot AI movement
            UpdateBotAI();

            // Score when ball goes out of bounds
            if (ball.X <= 0)
            {
                botScore++;
                ResetBall();
            }
            else if (ball.X >= gamePanel.Width - ball.Width)
            {
                playerScore++;
                ResetBall();
            }

            UpdateScore();
            gamePanel.Invalidate();
        }

        private void ResetBall()
        {
            ball.X = gamePanel.Width / 2 - 5;
            ball.Y = gamePanel.Height / 2 - 5;
            ballSpeedX = -ballSpeedX;
        }

        private void UpdateScore()
        {
            lblScore.Text = $"{playerScore} - {botScore}";
            
            // Check for winner
            if (playerScore >= 10 || botScore >= 10)
            {
                gameTimer.Stop();
                gameRunning = false;
                btnStart.Text = "Start Game";
                btnStart.BackColor = Color.FromArgb(76, 175, 80);
                
                string winner = playerScore >= 10 ? "You" : "Bot";
                MessageBox.Show($"{winner} win!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Reset scores
                playerScore = 0;
                botScore = 0;
                UpdateScore();
            }
        }
        
        private void UpdateBotAI()
        {
            // Bot AI - follows the ball precisely
            int botCenter = botPaddle.Y + botPaddle.Height / 2;
            int ballCenter = ball.Y + ball.Height / 2;
            
            // Bot always tracks the ball
            if (ballCenter < botCenter && botPaddle.Y > 0)
            {
                botPaddle.Y -= Math.Min(botSpeed, botCenter - ballCenter);
            }
            else if (ballCenter > botCenter && botPaddle.Y < gamePanel.Height - botPaddle.Height)
            {
                botPaddle.Y += Math.Min(botSpeed, ballCenter - botCenter);
            }
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!gameRunning) return;
            
            // Player paddle follows mouse Y position
            int newY = e.Y - playerPaddle.Height / 2;
            newY = Math.Max(0, Math.Min(gamePanel.Height - playerPaddle.Height, newY));
            playerPaddle.Y = newY;
            
            gamePanel.Invalidate();
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            // Draw paddles
            g.FillRectangle(Brushes.LightGreen, playerPaddle);
            g.FillRectangle(Brushes.OrangeRed, botPaddle);
            
            // Draw ball
            g.FillEllipse(Brushes.White, ball);
            
            // Draw center line
            using (Pen dashedPen = new Pen(Color.White, 2))
            {
                dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(dashedPen, gamePanel.Width / 2, 0, gamePanel.Width / 2, gamePanel.Height);
            }
            
            // Draw player names
            using (Font nameFont = new Font("Segoe UI", 10F))
            {
                g.DrawString("PLAYER", nameFont, Brushes.LightGreen, 10, 10);
                g.DrawString("BOT", nameFont, Brushes.OrangeRed, gamePanel.Width - 50, 10);
            }
        }
        
        // Override ProcessCmdKey to handle keyboard input at panel level
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!gameRunning) return base.ProcessCmdKey(ref msg, keyData);
            
            int moveSpeed = 20;
            
            switch (keyData)
            {
                case Keys.W:
                case Keys.Up:
                    if (playerPaddle.Y > 0)
                    {
                        playerPaddle.Y -= moveSpeed;
                        gamePanel.Invalidate();
                    }
                    return true;
                    
                case Keys.S:
                case Keys.Down:
                    if (playerPaddle.Y < gamePanel.Height - playerPaddle.Height)
                    {
                        playerPaddle.Y += moveSpeed;
                        gamePanel.Invalidate();
                    }
                    return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}