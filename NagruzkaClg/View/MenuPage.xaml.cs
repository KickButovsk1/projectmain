using System.Windows;
using System.Windows.Controls;

namespace NagruzkaClg.View;

public partial class MenuPage : Page
{
    public MenuPage()
    {
        InitializeComponent();
    }

    private void NagruzkaButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new NagruzkaPage());
    }

    private void PlanButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new PlanPage());
    }

    private void ProfileButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ProfilePage());
    }

    private void SpecializationsButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new SpecializationsPage());
    }

    private void GroupsButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new GroupsPage());
    }
}