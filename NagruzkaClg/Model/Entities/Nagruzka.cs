using System.Security.Principal;

namespace NagruzkaClg.Model.Entities;

public class Nagruzka
{
    public int Id { get; set; }
    public Disciplines Discipline { get; set; }
    
    public Teachers Teacher { get; set; }
    
    public Plan Plan { get; set; }
    
    public Groups Group { get; set; }
    
    public ICollection<Load> Loads { get; set; } = [];
}