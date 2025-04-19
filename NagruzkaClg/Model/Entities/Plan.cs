namespace NagruzkaClg.Model.Entities;

public class Plan
{
    public int Id { get; set; }
    
    public int TeoryHours { get; set; }
    
    public int Semestr { get; set; }
    
    public int PracticeHours { get; set; }
    
    public int SelfHours { get; set; }
    
    public int KursHours { get; set; }
    
    public Specialize Specialize { get; set; }
    
    public ICollection<Nagruzka> Nagruzki { get; set; } = [];
}