using Microsoft.EntityFrameworkCore;
using NagruzkaClg.Model.Entities;

namespace NagruzkaClg.Controllers;


public class UsersController
{
    private readonly AppDbContext _context;
    public UsersController(AppDbContext context)
    {
        _context = context;
        
    }
    public bool CheckAuth(string login, string password)
    {
        try
        {
            if (!_context.Database.CanConnect())
            {
                throw new Exception("Ошибка подключения к базе данных");
            }

            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Логин не может быть пустым");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Пароль не может быть пустым");

            var user = _context.Users
                .FirstOrDefault(u => u.Login.ToLower() == login.Trim().ToLower());

            if (user == null)
                throw new Exception("Пользователь с таким логином не найден");

            if (user.Password != password)
                throw new Exception("Неверный пароль");

            return true;
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Ошибка работы с базой данных", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка авторизации: {ex.Message}", ex);
        }
    }
}