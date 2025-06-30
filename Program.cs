using Microsoft.Extensions.Configuration;
using Arduino.Services;
using Arduino.Forms;

namespace Arduino
{
    internal static class Program
    {
        public static AuthenticationService AuthService { get; private set; }
        public static DatabaseService DatabaseService { get; private set; }
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // โหลด configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            
            // สร้าง services
            var connectionString = configuration.GetConnectionString("SQLite");
            DatabaseService = new DatabaseService(connectionString);
            AuthService = new AuthenticationService(DatabaseService);
            
            // แสดง Login Form
            using (var loginForm = new LoginForm(AuthService))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login สำเร็จ เปิด Main Form
                    Application.Run(new Form1());
                }
            }
        }
    }
}