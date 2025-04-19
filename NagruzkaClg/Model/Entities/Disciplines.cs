namespace NagruzkaClg.Model.Entities;

public class Disciplines
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Nagruzka> Nagruzki { get; set; } = new List<Nagruzka>();
}