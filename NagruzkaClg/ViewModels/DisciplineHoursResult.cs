namespace NagruzkaClg.ViewModels;

public class DisciplineHoursResult
{
    public int DisciplineId { get; set; }
    public string DisciplineTitle { get; set; }
    public int TheoryHours { get; set; }
    public int PracticeHours { get; set; }
    public int SelfHours { get; set; }
    public int KursHours { get; set; }
    public int TotalHours { get; set; }
}