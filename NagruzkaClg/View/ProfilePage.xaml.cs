using System.Windows.Controls;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.View;

public partial class ProfilePage : Page
{
    private readonly AppDbContext _context;
    public ProfilePage()
    {
        _context = new AppDbContext();
        InitializeComponent();
    }
}