using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NagruzkaClg.Controllers;
using NagruzkaClg.Model.Entities;
using NagruzkaClg.View;

namespace NagruzkaClg
{
    public partial class App : Application
    {
        public  IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем контейнер
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Собираем провайдер
            ServiceProvider = services.BuildServiceProvider();

            DispatcherUnhandledException += (s, ex) => 
            {
                MessageBox.Show($"Ошибка: {ex.Exception.Message}");
                ex.Handled = true;
            };
            // Запускаем главное окно через DI
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрируем главное окно (Singleton, чтобы не создавалось повторно)
            services.AddSingleton<MainWindow>();

            // Регистрируем страницы
            services.AddTransient<LoginPage>();

            // Регистрируем контроллеры
            services.AddTransient<GroupsController>();
            services.AddTransient<SpecializeController>();
            services.AddTransient<TeacherController>();
            services.AddTransient<UsersController>();

            // Регистрируем контекст базы данных
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NagruzkaCollege;Trusted_Connection=True;"));
        }
    }
}