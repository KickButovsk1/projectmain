namespace NagruzkaClg.Model.Entities;

public class Users
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}