using System.Windows;
using System.Windows.Controls;
using NagruzkaClg.Controllers;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.View;

public partial class LoginPage : Page
{
  
    private readonly UsersController _user;
    public LoginPage(UsersController user)
    {
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
                NavigationService.Navigate(new MenuPage());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
    }
}