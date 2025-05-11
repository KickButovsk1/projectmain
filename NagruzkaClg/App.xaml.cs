using System;
using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NagruzkaClg.Controllers;
using NagruzkaClg.Model.Entities;
using NagruzkaClg.Services;
using NagruzkaClg.View;

namespace NagruzkaClg
{
    public partial class App : Application
    {
        public  IServiceProvider ServiceProvider { get; private set; }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
                
            string backupDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NagruzkaClg", "Backups");
            Directory.CreateDirectory(backupDir);
            string backupFile = Path.Combine(backupDir, "backup.json");

            var services = new ServiceCollection();
            ConfigureServices(services);
            
            ServiceProvider = services.BuildServiceProvider();

            DispatcherUnhandledException += (s, ex) => 
            {
                MessageBox.Show($"Ошибка: {ex.Exception.Message}");
                ex.Handled = true;
            };
            
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            mainWindow.LoadLoginPage();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            
            services.AddTransient<LoginPage>();
            services.AddTransient<AddGroupPage>();
            services.AddTransient<EditGroupPage>();
            services.AddTransient<GroupsPage>();
            services.AddTransient<MenuPage>();
            services.AddTransient<NagruzkaPage>();
            services.AddTransient<PlanPage>();
            services.AddTransient<ProfilePage>();
            services.AddTransient<SpecializationsPage>();
            
            services.AddTransient<GroupsController>();
            services.AddTransient<SpecializeController>();
            services.AddTransient<TeacherController>();
            services.AddTransient<UsersController>();
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjectDB;Trusted_Connection=True;"));
        }
    }
}