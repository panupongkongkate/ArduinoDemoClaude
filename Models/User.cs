using System;

namespace Arduino.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
    }

    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Viewer = "Viewer";
    }
}