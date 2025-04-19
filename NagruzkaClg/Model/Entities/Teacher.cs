namespace NagruzkaClg.Model.Entities;

public class Teachers
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string? Image { get; set; }
    public ICollection<Load> Loads { get; set; } = [];
    public ICollection<Nagruzka> Nagruzki { get; set; } = [];
}