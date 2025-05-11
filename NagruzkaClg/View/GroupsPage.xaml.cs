using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using NagruzkaClg.Controllers;
using NagruzkaClg.Model.Entities;
using NagruzkaClg.ViewModels;

namespace NagruzkaClg.View;

public partial class GroupsPage : Page
{
    private readonly IServiceProvider _serviceProvider;
    private readonly GroupsController _groupController;
    private ObservableCollection<Groups> _groups;
        
    public GroupsPage(GroupsController groupController, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _groupController=groupController;
        _groups=new ObservableCollection<Groups>();
        InitializeComponent();
        Loaded += Page_Loaded;
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            var groups = await _groupController.GetAllGroupsAsync();
            _groups.Clear();
            foreach (var group in groups)
            {
                _groups.Add(group);
            }
            GroupsListView.ItemsSource = _groups;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки групп: {ex.Message}");
        }
        /*try
        {
            if (_groupController == null)
            {
                MessageBox.Show("GroupController не инициализирован");
                return;
            }

            var groups = await _groupController.GetAllGroupsAsync();
        
            if (groups == null)
            {
                MessageBox.Show("Список групп равен null");
                return;
            }

            if (GroupsListView == null)
            {
                MessageBox.Show("ListView не найден в XAML");
                return;
            }

            GroupsListView.ItemsSource = groups;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки групп: {ex.Message}");
        }*/
    }

    private void AddGroupButton_OnClick(object sender, RoutedEventArgs e)
    {
        var AddGrpPage = _serviceProvider.GetRequiredService<AddGroupPage>();
        NavigationService.Navigate(AddGrpPage);
    }

    
    
    private async void DeleteGroupButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (GroupsListView.SelectedItem is Groups selectedGroup)
        {
            try
            {
                // Запрос подтверждения
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить группу '{selectedGroup.Name}'?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    await _groupController.DeleteGroupByIdAsync(selectedGroup.Id);
                    _groups.Remove(selectedGroup);
                    MessageBox.Show("Группа успешно удалена");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Выберите группу для удаления");
        }
    }
    
    private async void EditButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (GroupsListView.SelectedItem is Groups selectedGroup)
        {
            var editPage = _serviceProvider.GetRequiredService<EditGroupPage>();
            editPage.SetGroupData(selectedGroup); // Передаем выбранную группу
            NavigationService.Navigate(editPage);
        }
        else
        {
            MessageBox.Show("Выберите группу для редактирования");
        }
    }
}
