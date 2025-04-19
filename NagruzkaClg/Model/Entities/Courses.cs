namespace NagruzkaClg.Model.Entities;

public class Courses
{
    public int Id { get; set; }
    public string CourseLevel { get; set; }
    public ICollection<Groups> Groups { get; set; } =[];
}