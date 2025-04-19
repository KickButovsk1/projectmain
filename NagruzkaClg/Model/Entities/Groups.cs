namespace NagruzkaClg.Model.Entities;

public class Groups
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Specialize Specialize { get; set; }
    public FreeOrSpend FreeOrSpend { get; set; }
    public ObuchenieForm ObuchenieForm { get; set; }
    
    public Courses Course { get; set; }
    
    public ICollection<Nagruzka>  Nagruzka{ get; set; } = [];
    
}