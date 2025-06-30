using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Arduino.Models;
using System.IO;

namespace Arduino.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    PasswordHash TEXT NOT NULL,
                    Role TEXT NOT NULL,
                    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
                    LastLogin DATETIME
                );
            ";
            command.ExecuteNonQuery();

            // เพิ่ม Admin user เริ่มต้นถ้ายังไม่มี
            command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'";
            var count = Convert.ToInt32(command.ExecuteScalar());
            
            if (count == 0)
            {
                // Password เริ่มต้นคือ "admin123"
                var adminPassword = BCrypt.Net.BCrypt.HashPassword("admin123");
                command.CommandText = @"
                    INSERT INTO Users (Username, PasswordHash, Role, CreatedAt)
                    VALUES ('admin', @password, @role, @createdAt)
                ";
                command.Parameters.AddWithValue("@password", adminPassword);
                command.Parameters.AddWithValue("@role", UserRoles.Admin);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);
                command.ExecuteNonQuery();
            }
            
            // เพิ่ม test User สำหรับ demo
            command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'user'";
            count = Convert.ToInt32(command.ExecuteScalar());
            
            if (count == 0)
            {
                var userPassword = BCrypt.Net.BCrypt.HashPassword("user123");
                command.CommandText = @"
                    INSERT INTO Users (Username, PasswordHash, Role, CreatedAt)
                    VALUES ('user', @password, @role, @createdAt)
                ";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@password", userPassword);
                command.Parameters.AddWithValue("@role", UserRoles.User);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);
                command.ExecuteNonQuery();
            }
            
            // เพิ่ม test Viewer สำหรับ demo
            command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'viewer'";
            count = Convert.ToInt32(command.ExecuteScalar());
            
            if (count == 0)
            {
                var viewerPassword = BCrypt.Net.BCrypt.HashPassword("viewer123");
                command.CommandText = @"
                    INSERT INTO Users (Username, PasswordHash, Role, CreatedAt)
                    VALUES ('viewer', @password, @role, @createdAt)
                ";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@password", viewerPassword);
                command.Parameters.AddWithValue("@role", UserRoles.Viewer);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, Username, PasswordHash, Role, CreatedAt, LastLogin
                FROM Users
                WHERE Username = @username
            ";
            command.Parameters.AddWithValue("@username", username);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    Role = reader.GetString(3),
                    CreatedAt = reader.GetDateTime(4),
                    LastLogin = reader.IsDBNull(5) ? null : reader.GetDateTime(5)
                };
            }

            return null;
        }

        public async Task UpdateLastLoginAsync(int userId)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Users SET LastLogin = @lastLogin WHERE Id = @id";
            command.Parameters.AddWithValue("@lastLogin", DateTime.Now);
            command.Parameters.AddWithValue("@id", userId);
            
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = new List<User>();
            
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, Username, PasswordHash, Role, CreatedAt, LastLogin
                FROM Users
                ORDER BY Username
            ";

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    PasswordHash = reader.GetString(2),
                    Role = reader.GetString(3),
                    CreatedAt = reader.GetDateTime(4),
                    LastLogin = reader.IsDBNull(5) ? null : reader.GetDateTime(5)
                });
            }

            return users;
        }

        public async Task<bool> CreateUserAsync(string username, string password, string role)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandText = @"
                    INSERT INTO Users (Username, PasswordHash, Role, CreatedAt)
                    VALUES (@username, @passwordHash, @role, @createdAt)
                ";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(password));
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch (SqliteException)
            {
                return false; // Username already exists
            }
        }

        public async Task<bool> UpdateUserAsync(int id, string newPassword, string role)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            
            if (!string.IsNullOrEmpty(newPassword))
            {
                command.CommandText = @"
                    UPDATE Users 
                    SET PasswordHash = @passwordHash, Role = @role
                    WHERE Id = @id
                ";
                command.Parameters.AddWithValue("@passwordHash", BCrypt.Net.BCrypt.HashPassword(newPassword));
            }
            else
            {
                command.CommandText = "UPDATE Users SET Role = @role WHERE Id = @id";
            }
            
            command.Parameters.AddWithValue("@role", role);
            command.Parameters.AddWithValue("@id", id);

            var result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.OpenAsync();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Users WHERE Id = @id AND Username != 'admin'";
            command.Parameters.AddWithValue("@id", id);

            var result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }
    }
}