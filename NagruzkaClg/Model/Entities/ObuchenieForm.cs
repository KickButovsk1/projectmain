namespace NagruzkaClg.Model.Entities;

public class ObuchenieForm
{
    public int Id { get; set; }
    public string Form { get; set; }
    public ICollection<Groups> Groups { get; set; } = new List<Groups>();
}