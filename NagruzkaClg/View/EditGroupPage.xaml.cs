using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NagruzkaClg.Controllers;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.View;

public partial class EditGroupPage : Page
{
    private readonly AppDbContext _context ;
    private readonly GroupsController _groupsController;
    private Groups _currentGroup;
    
    public EditGroupPage(AppDbContext context, GroupsController groupsController)
    {
        _context = context;
        _groupsController = groupsController;
        InitializeComponent();
        Loaded += Page_Loaded;
    }

    public void SetGroupData(Groups group)
    {
        _currentGroup = group;
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            var specializes = await _context.Specializes.ToListAsync();
            var freeOrSpend = await _context.FreeOrSpend.ToListAsync();
            var obuchenieForm = await _context.ObuchenieForm.ToListAsync();
            var course = await _context.Courses.ToListAsync();

            SpecializationComboBox.ItemsSource = specializes;
            FOSComboBox.ItemsSource = freeOrSpend;
            ObuchenieFormComboBox.ItemsSource = obuchenieForm;
            CourseComboBox.ItemsSource = course;

            if (_currentGroup != null)
            {
                NameTextBox.Text = _currentGroup.Name;
                SpecializationComboBox.SelectedValue = _currentGroup.Specialize?.Id;
                FOSComboBox.SelectedValue = _currentGroup.FreeOrSpend?.Id;
                ObuchenieFormComboBox.SelectedValue = _currentGroup.ObuchenieForm?.Id;
                CourseComboBox.SelectedValue = _currentGroup.Course?.Id;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
        }
    }

    private async void EditButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (_currentGroup == null) return;

        try
        {
            await _groupsController.UpdateGroupAsync(
                _currentGroup.Id,
                NameTextBox.Text,
                (int)SpecializationComboBox.SelectedValue,
                (int)FOSComboBox.SelectedValue,
                (int)ObuchenieFormComboBox.SelectedValue,
                (int)CourseComboBox.SelectedValue,
                _currentGroup.Nagruzka?.ToList() ?? new List<Nagruzka>());

            MessageBox.Show("Группа успешно обновлена");
            NavigationService.GoBack();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при обновлении группы: {ex.Message}");
        }
    }
}