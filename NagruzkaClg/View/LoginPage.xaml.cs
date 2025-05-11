using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using NagruzkaClg.Controllers;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.View;

public partial class LoginPage : Page
{
  
    private readonly UsersController _user;
    private readonly IServiceProvider _serviceProvider;
    public LoginPage(UsersController user, IServiceProvider serviceProvider)
    {
        _serviceProvider =  serviceProvider;
        _user = user; 
        InitializeComponent();
    }
    
    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var login = LoginTextBox.Text.Trim();
            var password = PasswordTextBox.Password.Trim();
        
            if (_user.CheckAuth(login, password))
            {
                var menupage = _serviceProvider.GetRequiredService<MenuPage>();
                NavigationService.Navigate(menupage);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
    }
}