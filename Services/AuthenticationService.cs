using System;
using System.Threading.Tasks;
using Arduino.Models;

namespace Arduino.Services
{
    public class AuthenticationService
    {
        private readonly DatabaseService _databaseService;
        private User _currentUser;
        private int _loginAttempts = 0;
        private readonly int _maxLoginAttempts;

        public User CurrentUser => _currentUser;
        public bool IsAuthenticated => _currentUser != null;

        public AuthenticationService(DatabaseService databaseService, int maxLoginAttempts = 3)
        {
            _databaseService = databaseService;
            _maxLoginAttempts = maxLoginAttempts;
        }

        public async Task<(bool success, string message)> LoginAsync(string username, string password)
        {
            // ตรวจสอบจำนวนครั้งที่ล็อกอินผิด
            if (_loginAttempts >= _maxLoginAttempts)
            {
                return (false, $"Login ผิดเกิน {_maxLoginAttempts} ครั้ง กรุณาปิดโปรแกรมแล้วเปิดใหม่");
            }

            // ตรวจสอบ input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                _loginAttempts++;
                return (false, "กรุณากรอก Username และ Password");
            }

            // ดึงข้อมูล user จากฐานข้อมูล
            var user = await _databaseService.GetUserByUsernameAsync(username);
            
            if (user == null)
            {
                _loginAttempts++;
                return (false, "Username หรือ Password ไม่ถูกต้อง");
            }

            // ตรวจสอบ password
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                _loginAttempts++;
                return (false, "Username หรือ Password ไม่ถูกต้อง");
            }

            // Login สำเร็จ
            _currentUser = user;
            _loginAttempts = 0;
            
            // อัพเดท last login
            await _databaseService.UpdateLastLoginAsync(user.Id);
            
            return (true, "Login สำเร็จ");
        }

        public void Logout()
        {
            _currentUser = null;
            _loginAttempts = 0;
        }

        public bool HasPermission(string requiredRole)
        {
            if (!IsAuthenticated) return false;

            // Admin มีสิทธิ์ทุกอย่าง
            if (_currentUser.Role == UserRoles.Admin) return true;

            // User มีสิทธิ์ของ User และ Viewer
            if (_currentUser.Role == UserRoles.User && 
                (requiredRole == UserRoles.User || requiredRole == UserRoles.Viewer))
            {
                return true;
            }

            // Viewer มีสิทธิ์แค่ Viewer
            if (_currentUser.Role == UserRoles.Viewer && requiredRole == UserRoles.Viewer)
            {
                return true;
            }

            return false;
        }

        public bool CanControlDevices()
        {
            return HasPermission(UserRoles.User);
        }

        public bool CanManageUsers()
        {
            return HasPermission(UserRoles.Admin);
        }

        public void ResetLoginAttempts()
        {
            _loginAttempts = 0;
        }
    }
}