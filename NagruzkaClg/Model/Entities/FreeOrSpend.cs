namespace NagruzkaClg.Model.Entities;

public class FreeOrSpend
{
    public int Id { get; set; }
    public string FreeSpend { get; set; }
    public ICollection<Groups> Groups { get; set; } = new List<Groups>();
}