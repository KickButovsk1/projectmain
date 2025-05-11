using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using NagruzkaClg.View;

namespace NagruzkaClg
{
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            // Загружаем стартовую страницу
            LoadLoginPage();
        }

        public void LoadLoginPage()
        {
            var loginPage = _serviceProvider.GetRequiredService<LoginPage>();
            MainFrame.Navigate(loginPage);
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}