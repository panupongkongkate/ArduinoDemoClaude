using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Arduino.Models;
using Arduino.Services;

namespace Arduino.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly DatabaseService _databaseService;
        private User _selectedUser;
        
        public UserManagementForm()
        {
            _databaseService = Program.DatabaseService;
            InitializeComponent();
        }

        private async void UserManagementForm_Load(object sender, EventArgs e)
        {
            // โหลด Roles ใน ComboBox
            comboBoxRole.Items.Clear();
            comboBoxRole.Items.AddRange(new[] { UserRoles.Admin, UserRoles.User, UserRoles.Viewer });
            comboBoxRole.SelectedIndex = 1; // Default to User
            
            // โหลดรายการ Users
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                listViewUsers.Items.Clear();
                var users = await _databaseService.GetAllUsersAsync();
                
                foreach (var user in users)
                {
                    var item = new ListViewItem(user.Id.ToString());
                    item.SubItems.Add(user.Username);
                    item.SubItems.Add(user.Role);
                    item.SubItems.Add(user.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
                    item.SubItems.Add(user.LastLogin?.ToString("dd/MM/yyyy HH:mm") ?? "Never");
                    item.Tag = user;
                    listViewUsers.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                _selectedUser = (User)listViewUsers.SelectedItems[0].Tag;
                
                // แสดงข้อมูลใน form
                textBoxUsername.Text = _selectedUser.Username;
                comboBoxRole.SelectedItem = _selectedUser.Role;
                
                // ปิดการแก้ไข username
                textBoxUsername.ReadOnly = true;
                
                // เปลี่ยนปุ่มเป็น Update
                buttonSave.Text = "Update";
                
                // Enable/Disable Delete button (ห้ามลบ admin)
                buttonDelete.Enabled = _selectedUser.Username != "admin";
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("กรุณากรอก Username", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxRole.SelectedItem == null)
            {
                MessageBox.Show("กรุณาเลือก Role", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = false;
                
                if (_selectedUser == null)
                {
                    // สร้าง User ใหม่
                    if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
                    {
                        MessageBox.Show("กรุณากรอก Password สำหรับ User ใหม่", "Validation Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    success = await _databaseService.CreateUserAsync(
                        textBoxUsername.Text, 
                        textBoxPassword.Text,
                        comboBoxRole.SelectedItem.ToString()
                    );
                    
                    if (success)
                    {
                        MessageBox.Show("สร้าง User สำเร็จ", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Username นี้มีอยู่แล้ว", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // อัพเดท User
                    success = await _databaseService.UpdateUserAsync(
                        _selectedUser.Id,
                        textBoxPassword.Text, // ถ้าว่างจะไม่เปลี่ยน password
                        comboBoxRole.SelectedItem.ToString()
                    );
                    
                    if (success)
                    {
                        MessageBox.Show("อัพเดท User สำเร็จ", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (success)
                {
                    ClearForm();
                    await LoadUsersAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null) return;
            
            if (_selectedUser.Username == "admin")
            {
                MessageBox.Show("ไม่สามารถลบ admin user ได้", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"ต้องการลบ User '{_selectedUser.Username}' หรือไม่?", 
                "Confirm Delete", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var success = await _databaseService.DeleteUserAsync(_selectedUser.Id);
                    if (success)
                    {
                        MessageBox.Show("ลบ User สำเร็จ", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        await LoadUsersAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedUser = null;
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            comboBoxRole.SelectedIndex = 1; // Default to User
            textBoxUsername.ReadOnly = false;
            buttonSave.Text = "Create";
            buttonDelete.Enabled = false;
            listViewUsers.SelectedItems.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}