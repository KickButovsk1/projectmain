namespace NagruzkaClg.Model.Entities;

public class Load
{
    public int Id { get; set; }
    public int LoadsHours { get; set; }
    
    public Teachers Teacher { get; set; }
    
    public Nagruzka Nagruzka { get; set; }
}