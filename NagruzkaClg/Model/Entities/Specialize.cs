namespace NagruzkaClg.Model.Entities;

public class Specialize
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Groups> Groups { get; set; } = [];
    public ICollection<Plan> Plans { get; set; } = [];

}