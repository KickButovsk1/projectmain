using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.View;

public partial class AddGroupPage : Page
{
    private readonly AppDbContext _context;
    public AddGroupPage(AppDbContext context)
    {
        _context = context;
        InitializeComponent();
    }

    private async void Page_Loaded(object? sender, EventArgs e)
    {
        try
        {
            var specializes = await _context.Specializes.ToListAsync();
            var freeOrSpend = await _context.FreeOrSpend.ToListAsync();
            var obuchenieForm = await _context.ObuchenieForm.ToListAsync();
            var courses = await _context.Courses.ToListAsync();
            
            SpecializationComboBox.ItemsSource=specializes;
            FOSComboBox.ItemsSource=freeOrSpend;
            ObuchenieFormComboBox.ItemsSource=obuchenieForm;
            CourseComboBox.ItemsSource=courses;

            SpecializationComboBox.SelectedIndex = -1;
            FOSComboBox.SelectedIndex = -1;
            ObuchenieFormComboBox.SelectedIndex = -1;
            CourseComboBox.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            Debug.WriteLine(ex.ToString());
        }
    }
    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
            SpecializationComboBox == null ||
            FOSComboBox == null ||
            ObuchenieFormComboBox == null ||
            CourseComboBox == null)
        {
            MessageBox.Show("Заполните все поля!");
            return;
        }

        var newGroup = new Groups()
        {
            Name = NameTextBox.Text,
            Specialize = (Specialize)SpecializationComboBox.SelectedItem,
            FreeOrSpend = (FreeOrSpend)FOSComboBox.SelectedItem,
            ObuchenieForm = (ObuchenieForm)ObuchenieFormComboBox.SelectedItem,
            Course = (Courses)CourseComboBox.SelectedItem
        };
        try
        {
            _context.Groups.Add(newGroup);
            _context.SaveChanges();
            MessageBox.Show("Группа добавлена!");
            NameTextBox.Clear();
            SpecializationComboBox.SelectedIndex = -1;
            FOSComboBox.SelectedIndex = -1;
            ObuchenieFormComboBox.SelectedIndex = -1;
            CourseComboBox.SelectedIndex = -1;
        }
        catch
        {
            MessageBox.Show("Ошибка при добавлении группы.");
        }
    }
}