using System;
using System.Windows.Forms;
using System.IO.Ports;
using Arduino.Models;
using Arduino.Forms;

namespace Arduino
{
    public partial class Form1 : Form
    {
        // ตัวแปรสำหรับเก็บ Serial Port object
        SerialPort port;
        
        public Form1()
        {
            InitializeComponent();
            // เพิ่ม event handler สำหรับเมื่อปิด Form
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }
        
        // Event handler เมื่อ Form โหลดเสร็จ
        private void Form1_Load(object sender, EventArgs e)
        {
            // โหลดรายการ COM ports ที่มีในระบบ
            RefreshPortList();
            
            // สร้างรูป LED เริ่มต้น (ปิด)
            UpdateLEDIndicator(false);
            
            // แสดงข้อมูล User และจัดการสิทธิ์
            SetupUserInterface();
        }
        
        // ฟังก์ชันสำหรับรีเฟรชรายการ COM ports
        private void RefreshPortList()
        {
            // ล้างรายการเดิม
            comboBoxPorts.Items.Clear();
            
            // ดึงรายการ COM ports ทั้งหมดที่มีในระบบ
            string[] ports = SerialPort.GetPortNames();
            comboBoxPorts.Items.AddRange(ports);
            
            // เลือก port แรกเป็นค่าเริ่มต้น ถ้ามี port อยู่
            if (comboBoxPorts.Items.Count > 0)
            {
                comboBoxPorts.SelectedIndex = 0;
            }
        }
        
        // Event handler เมื่อปิด Form - ปิด Serial Port ถ้ายังเปิดอยู่
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // หยุด Timer
            if (connectionTimer != null)
            {
                connectionTimer.Stop();
            }
            
            // ปิด Serial Port
            if (port != null && port.IsOpen)
            {
                port.Close();
            }
        }
        
        // Event handler สำหรับปุ่ม Connect/Disconnect
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่าตอนนี้เชื่อมต่ออยู่หรือไม่
            if (port == null || !port.IsOpen)
            {
                // กรณียังไม่ได้เชื่อมต่อ - ทำการเชื่อมต่อ
                if (comboBoxPorts.SelectedItem != null)
                {
                    try
                    {
                        // สร้าง Serial Port object ด้วย port ที่เลือกและ baud rate 9600
                        port = new SerialPort(comboBoxPorts.SelectedItem.ToString(), 9600);
                        port.Open();
                        
                        // อัพเดท UI เมื่อเชื่อมต่อสำเร็จ
                        buttonConnect.Text = "Disconnect";
                        labelStatus.Text = "Connected to " + comboBoxPorts.SelectedItem.ToString();
                        labelStatus.ForeColor = System.Drawing.Color.Green;
                        button1.Enabled = true;     // เปิดใช้งานปุ่ม LED ON
                        button2.Enabled = true;     // เปิดใช้งานปุ่ม LED OFF
                        comboBoxPorts.Enabled = false;  // ปิดการเลือก port ขณะเชื่อมต่อ
                        
                        // เริ่ม Timer สำหรับตรวจสอบการเชื่อมต่อ
                        connectionTimer.Start();
                    }
                    catch (Exception ex)
                    {
                        // แสดงข้อความเมื่อเกิดข้อผิดพลาดในการเชื่อมต่อ
                        MessageBox.Show("Error: " + ex.Message, "Connection Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // แจ้งเตือนถ้ายังไม่ได้เลือก COM port
                    MessageBox.Show("Please select a COM port", "No Port Selected", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // กรณีกำลังเชื่อมต่ออยู่ - ทำการตัดการเชื่อมต่อ
                connectionTimer.Stop(); // หยุด Timer
                
                if (port.IsOpen)
                {
                    port.Close();
                }
                
                // อัพเดท UI เมื่อตัดการเชื่อมต่อ
                buttonConnect.Text = "Connect";
                labelStatus.Text = "Disconnected";
                labelStatus.ForeColor = System.Drawing.Color.Red;
                button1.Enabled = false;    // ปิดใช้งานปุ่ม LED ON
                button2.Enabled = false;    // ปิดใช้งานปุ่ม LED OFF
                comboBoxPorts.Enabled = true;   // เปิดให้เลือก port ได้อีกครั้ง
                
                // รีเฟรชรายการ ports เผื่อมี port ใหม่เพิ่มเข้ามา
                RefreshPortList();
            }
        }
        
        // Event handler สำหรับปุ่ม LED ON - ส่งคำสั่ง '1' ไปยัง Arduino
        private void button1_Click(object sender, EventArgs e)
        {
            PortWrite("1");
            UpdateLEDIndicator(true);
        }
        
        // Event handler สำหรับปุ่ม LED OFF - ส่งคำสั่ง '0' ไปยัง Arduino
        private void button2_Click(object sender, EventArgs e)
        {
            PortWrite("0");
            UpdateLEDIndicator(false);
        }
        
        // ฟังก์ชันสำหรับส่งข้อมูลผ่าน Serial Port
        private void PortWrite(string message)
        {
            try
            {
                // ตรวจสอบว่า port เปิดอยู่หรือไม่ก่อนส่งข้อมูล
                if (port != null && port.IsOpen)
                {
                    port.Write(message);
                }
            }
            catch (Exception ex)
            {
                // แสดงข้อความเมื่อเกิดข้อผิดพลาดในการส่งข้อมูล
                MessageBox.Show("Error writing to port: " + ex.Message, "Write Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // ฟังก์ชันสำหรับอัพเดทรูป LED indicator
        private void UpdateLEDIndicator(bool isOn)
        {
            using (var bitmap = new System.Drawing.Bitmap(40, 40))
            {
                using (var g = System.Drawing.Graphics.FromImage(bitmap))
                {
                    // Anti-aliasing สำหรับวงกลมที่เรียบ
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    
                    // วาดเงา
                    using (var shadowBrush = new System.Drawing.SolidBrush(
                        System.Drawing.Color.FromArgb(50, 0, 0, 0)))
                    {
                        g.FillEllipse(shadowBrush, 2, 2, 36, 36);
                    }
                    
                    // วาด LED
                    System.Drawing.Color ledColor = isOn ? 
                        System.Drawing.Color.FromArgb(255, 0, 0) :  // สีแดงเมื่อเปิด
                        System.Drawing.Color.FromArgb(100, 0, 0);   // สีแดงเข้มเมื่อปิด
                    
                    using (var ledBrush = new System.Drawing.SolidBrush(ledColor))
                    {
                        g.FillEllipse(ledBrush, 0, 0, 36, 36);
                    }
                    
                    // เพิ่มเอฟเฟกต์แสง
                    if (isOn)
                    {
                        using (var glowBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                            new System.Drawing.Rectangle(5, 5, 26, 26),
                            System.Drawing.Color.FromArgb(200, 255, 100, 100),
                            System.Drawing.Color.FromArgb(50, 255, 0, 0),
                            45f))
                        {
                            g.FillEllipse(glowBrush, 5, 5, 26, 26);
                        }
                    }
                    
                    // วาดขอบ
                    using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(50, 0, 0, 0), 2))
                    {
                        g.DrawEllipse(pen, 1, 1, 34, 34);
                    }
                }
                
                pictureBoxLED.Image = bitmap.Clone() as System.Drawing.Bitmap;
            }
        }
        
        // ฟังก์ชันสำหรับตั้งค่า UI ตามสิทธิ์ของ User
        private void SetupUserInterface()
        {
            var currentUser = Program.AuthService.CurrentUser;
            
            // แสดงข้อมูล User ใน Top Bar
            labelUserName.Text = currentUser.Username;
            labelUserRole.Text = currentUser.Role;
            
            // แสดงข้อมูล User ใน Status Bar
            toolStripStatusLabelUser.Text = $"User: {currentUser.Username} ({currentUser.Role})";
            
            // แสดง/ซ่อนเมนู User Management ตามสิทธิ์
            buttonMenuUsers.Visible = Program.AuthService.CanManageUsers();
            
            // เริ่มต้นที่หน้า Dashboard
            ShowDashboard();
        }
        
        // Event handler สำหรับปุ่ม Logout
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("ต้องการ Logout หรือไม่?", "Confirm Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                // ปิด Serial Port ถ้าเปิดอยู่
                if (port != null && port.IsOpen)
                {
                    port.Close();
                }
                
                // Logout
                Program.AuthService.Logout();
                
                // ปิด Form นี้
                this.Hide();
                
                // แสดง Login Form อีกครั้ง
                using (var loginForm = new LoginForm(Program.AuthService))
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Login สำเร็จ กลับมาที่ Form นี้
                        this.Show();
                        // รีเฟรช UI ตามสิทธิ์ใหม่
                        SetupUserInterface();
                    }
                    else
                    {
                        // ถ้ากด Cancel ที่ Login ให้ปิดโปรแกรม
                        Application.Exit();
                    }
                }
            }
        }
        
        
        // Menu Event Handlers
        private void buttonMenuDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }
        
        private void buttonMenuArduino_Click(object sender, EventArgs e)
        {
            ShowArduinoControl();
        }
        
        private void buttonMenuUsers_Click(object sender, EventArgs e)
        {
            ShowUserManagement();
        }
        
        private void buttonMenuPongGame_Click(object sender, EventArgs e)
        {
            ShowPongGame();
        }
        
        
        // Helper Methods for showing different pages
        private void ShowDashboard()
        {
            // Update page title
            labelPageTitle.Text = "Dashboard";
            
            // Reset menu colors
            ResetMenuColors();
            buttonMenuDashboard.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            
            // Hide Arduino controls
            groupBoxConnection.Visible = false;
            groupBoxControl.Visible = false;
            
            // Show dashboard content (placeholder for now)
            var lblWelcome = new Label
            {
                Text = $"Welcome, {Program.AuthService.CurrentUser.Username}!",
                Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(25, 30, 40),
                AutoSize = true,
                Location = new System.Drawing.Point(30, 50)
            };
            
            var lblInfo = new Label
            {
                Text = "Select Arduino Control from the menu to start controlling your device.",
                Font = new System.Drawing.Font("Segoe UI", 12F),
                ForeColor = System.Drawing.Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new System.Drawing.Point(30, 100)
            };
            
            panelContent.Controls.Clear();
            panelContent.Controls.Add(lblWelcome);
            panelContent.Controls.Add(lblInfo);
        }
        
        private void ShowArduinoControl()
        {
            // Update page title
            labelPageTitle.Text = "Arduino Control";
            
            // Reset menu colors
            ResetMenuColors();
            buttonMenuArduino.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            
            // Clear content and add Arduino controls
            panelContent.Controls.Clear();
            panelContent.Controls.Add(groupBoxConnection);
            panelContent.Controls.Add(groupBoxControl);
            
            // Show Arduino controls
            groupBoxConnection.Visible = true;
            groupBoxControl.Visible = true;
            
            // ตรวจสอบสิทธิ์การควบคุมตาม Role
            bool canControl = Program.AuthService.CanControlDevices();
            
            if (!canControl)
            {
                // Viewer - ปิดการใช้งานการควบคุม
                buttonConnect.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                comboBoxPorts.Enabled = false;
                labelStatus.Text = "View Only Mode";
                labelStatus.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                // Admin และ User - เปิดใช้งานการควบคุม
                comboBoxPorts.Enabled = true;
                buttonConnect.Enabled = true;
                // button1 และ button2 จะ enabled เมื่อเชื่อมต่อแล้ว
                
                // ตรวจสอบสถานะการเชื่อมต่อและตั้งค่าปุ่มให้ถูกต้อง
                if (port != null && port.IsOpen)
                {
                    buttonConnect.Text = "Disconnect";
                    labelStatus.Text = "Connected to " + port.PortName;
                    labelStatus.ForeColor = System.Drawing.Color.Green;
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
                else
                {
                    buttonConnect.Text = "Connect";
                    labelStatus.Text = "Disconnected";
                    labelStatus.ForeColor = System.Drawing.Color.Red;
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
            }
        }
        
        private void ShowUserManagement()
        {
            // Update page title
            labelPageTitle.Text = "User Management";
            
            // Reset menu colors
            ResetMenuColors();
            buttonMenuUsers.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            
            // Clear content
            panelContent.Controls.Clear();
            
            // Hide Arduino controls
            groupBoxConnection.Visible = false;
            groupBoxControl.Visible = false;
            
            // Create and add user management controls
            var userPanel = CreateUserManagementPanel();
            panelContent.Controls.Add(userPanel);
        }
        
        private Panel CreateUserManagementPanel()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30)
            };
            
            // Create controls similar to UserManagementForm
            var groupBoxUsers = new GroupBox
            {
                Text = "User List",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(0, 0),
                Size = new Size(700, 250)
            };
            
            var listViewUsers = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(15, 25),
                Size = new Size(670, 210),
                Font = new Font("Segoe UI", 9F)
            };
            
            // Add columns
            listViewUsers.Columns.Add("ID", 50);
            listViewUsers.Columns.Add("Username", 150);
            listViewUsers.Columns.Add("Role", 100);
            listViewUsers.Columns.Add("Created At", 150);
            listViewUsers.Columns.Add("Last Login", 150);
            
            groupBoxUsers.Controls.Add(listViewUsers);
            
            // Create user form controls
            var groupBoxForm = new GroupBox
            {
                Text = "User Details",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(0, 260),
                Size = new Size(700, 180)
            };
            
            var labelUsername = new Label
            {
                Text = "Username:",
                Location = new Point(20, 35),
                Size = new Size(80, 20),
                Font = new Font("Segoe UI", 10F)
            };
            
            var textBoxUsername = new TextBox
            {
                Location = new Point(110, 32),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10F)
            };
            
            var labelPassword = new Label
            {
                Text = "Password:",
                Location = new Point(20, 70),
                Size = new Size(80, 20),
                Font = new Font("Segoe UI", 10F)
            };
            
            var textBoxPassword = new TextBox
            {
                Location = new Point(110, 67),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10F),
                PasswordChar = '*'
            };
            
            var labelRole = new Label
            {
                Text = "Role:",
                Location = new Point(350, 35),
                Size = new Size(50, 20),
                Font = new Font("Segoe UI", 10F)
            };
            
            var comboBoxRole = new ComboBox
            {
                Location = new Point(410, 32),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxRole.Items.AddRange(new[] { "Admin", "User", "Viewer" });
            comboBoxRole.SelectedIndex = 1;
            
            var buttonSave = new Button
            {
                Text = "Create",
                Location = new Point(110, 120),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            buttonSave.FlatAppearance.BorderSize = 0;
            
            var buttonDelete = new Button
            {
                Text = "Delete",
                Location = new Point(220, 120),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            buttonDelete.FlatAppearance.BorderSize = 0;
            
            var buttonClear = new Button
            {
                Text = "Clear",
                Location = new Point(330, 120),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(158, 158, 158),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            buttonClear.FlatAppearance.BorderSize = 0;
            
            groupBoxForm.Controls.AddRange(new Control[] {
                labelUsername, textBoxUsername,
                labelPassword, textBoxPassword,
                labelRole, comboBoxRole,
                buttonSave, buttonDelete, buttonClear
            });
            
            panel.Controls.Add(groupBoxUsers);
            panel.Controls.Add(groupBoxForm);
            
            // Load users
            LoadUsersToListView(listViewUsers);
            
            // Wire up events
            User selectedUser = null;
            
            listViewUsers.SelectedIndexChanged += (s, e) =>
            {
                if (listViewUsers.SelectedItems.Count > 0)
                {
                    selectedUser = (User)listViewUsers.SelectedItems[0].Tag;
                    textBoxUsername.Text = selectedUser.Username;
                    comboBoxRole.SelectedItem = selectedUser.Role;
                    textBoxUsername.ReadOnly = true;
                    buttonSave.Text = "Update";
                    buttonDelete.Enabled = selectedUser.Username != "admin";
                }
            };
            
            buttonClear.Click += (s, e) =>
            {
                selectedUser = null;
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                comboBoxRole.SelectedIndex = 1;
                textBoxUsername.ReadOnly = false;
                buttonSave.Text = "Create";
                buttonDelete.Enabled = false;
                listViewUsers.SelectedItems.Clear();
            };
            
            buttonSave.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
                {
                    MessageBox.Show("กรุณากรอก Username", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                bool success = false;
                
                if (selectedUser == null)
                {
                    if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
                    {
                        MessageBox.Show("กรุณากรอก Password สำหรับ User ใหม่", "Validation Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    success = await Program.DatabaseService.CreateUserAsync(
                        textBoxUsername.Text, 
                        textBoxPassword.Text,
                        comboBoxRole.SelectedItem.ToString()
                    );
                    
                    if (success)
                        MessageBox.Show("สร้าง User สำเร็จ", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Username นี้มีอยู่แล้ว", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    success = await Program.DatabaseService.UpdateUserAsync(
                        selectedUser.Id,
                        textBoxPassword.Text,
                        comboBoxRole.SelectedItem.ToString()
                    );
                    
                    if (success)
                        MessageBox.Show("อัพเดท User สำเร็จ", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                if (success)
                {
                    buttonClear.PerformClick();
                    LoadUsersToListView(listViewUsers);
                }
            };
            
            buttonDelete.Click += async (s, e) =>
            {
                if (selectedUser == null) return;
                
                var result = MessageBox.Show(
                    $"ต้องการลบ User '{selectedUser.Username}' หรือไม่?", 
                    "Confirm Delete", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question
                );
                
                if (result == DialogResult.Yes)
                {
                    var success = await Program.DatabaseService.DeleteUserAsync(selectedUser.Id);
                    if (success)
                    {
                        MessageBox.Show("ลบ User สำเร็จ", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonClear.PerformClick();
                        LoadUsersToListView(listViewUsers);
                    }
                }
            };
            
            return panel;
        }
        
        private async void LoadUsersToListView(ListView listView)
        {
            try
            {
                listView.Items.Clear();
                var users = await Program.DatabaseService.GetAllUsersAsync();
                
                foreach (var user in users)
                {
                    var item = new ListViewItem(user.Id.ToString());
                    item.SubItems.Add(user.Username);
                    item.SubItems.Add(user.Role);
                    item.SubItems.Add(user.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
                    item.SubItems.Add(user.LastLogin?.ToString("dd/MM/yyyy HH:mm") ?? "Never");
                    item.Tag = user;
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ResetMenuColors()
        {
            buttonMenuDashboard.BackColor = System.Drawing.Color.Transparent;
            buttonMenuArduino.BackColor = System.Drawing.Color.Transparent;
            buttonMenuUsers.BackColor = System.Drawing.Color.Transparent;
            buttonMenuPongGame.BackColor = System.Drawing.Color.Transparent;
        }
        
        private void ShowPongGame()
        {
            // Update page title
            labelPageTitle.Text = "Pong Game";
            
            // Reset menu colors
            ResetMenuColors();
            buttonMenuPongGame.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            
            // Clear content panel
            panelContent.Controls.Clear();
            
            // Create and add Pong Game panel
            var pongPanel = new PongGamePanel();
            pongPanel.Location = new System.Drawing.Point(20, 20);
            panelContent.Controls.Add(pongPanel);
        }
        
        // Add hover effects for menu buttons
        private void panelTopBar_Paint(object sender, PaintEventArgs e)
        {
            // Draw bottom border
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(230, 230, 230), 1))
            {
                e.Graphics.DrawLine(pen, 0, panelTopBar.Height - 1, panelTopBar.Width, panelTopBar.Height - 1);
            }
        }
        
        // Event handler สำหรับ Timer ตรวจสอบการเชื่อมต่อ
        private void connectionTimer_Tick(object sender, EventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                try
                {
                    // ตรวจสอบว่า port ยังเชื่อมต่ออยู่หรือไม่
                    // ถ้า Arduino หลุดจะเกิด exception
                    string[] availablePorts = SerialPort.GetPortNames();
                    bool portExists = false;
                    
                    foreach (string portName in availablePorts)
                    {
                        if (portName == port.PortName)
                        {
                            portExists = true;
                            break;
                        }
                    }
                    
                    if (!portExists)
                    {
                        // Port หายไป (สายหลุด)
                        HandleConnectionLost();
                    }
                }
                catch (Exception)
                {
                    // เกิดข้อผิดพลาดในการตรวจสอบ
                    HandleConnectionLost();
                }
            }
        }
        
        // ฟังก์ชันจัดการเมื่อการเชื่อมต่อหลุด
        private void HandleConnectionLost()
        {
            // หยุด Timer
            connectionTimer.Stop();
            
            // ปิด port
            try
            {
                if (port != null && port.IsOpen)
                {
                    port.Close();
                }
            }
            catch { }
            
            // อัพเดท UI
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateUIAfterDisconnection()));
            }
            else
            {
                UpdateUIAfterDisconnection();
            }
        }
        
        // ฟังก์ชันอัพเดท UI หลังการเชื่อมต่อหลุด
        private void UpdateUIAfterDisconnection()
        {
            buttonConnect.Text = "Connect";
            labelStatus.Text = "Connection Lost - Arduino Disconnected";
            labelStatus.ForeColor = System.Drawing.Color.Red;
            button1.Enabled = false;
            button2.Enabled = false;
            comboBoxPorts.Enabled = true;
            
            // แสดงข้อความแจ้งเตือน
            MessageBox.Show("การเชื่อมต่อกับ Arduino หลุด กรุณาตรวจสอบสายและเชื่อมต่อใหม่", 
                "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            // รีเฟรชรายการ ports
            RefreshPortList();
        }
    }
}
