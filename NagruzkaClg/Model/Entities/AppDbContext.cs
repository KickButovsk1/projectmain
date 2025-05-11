using Microsoft.EntityFrameworkCore;
using NagruzkaClg.Model.Entities;
using Microsoft.Extensions.Configuration;

namespace NagruzkaClg.Model.Entities;

public class AppDbContext:DbContext
{
    public  DbSet<Courses> Courses {  get; set; }
    public  DbSet<Disciplines> Disciplines {  get; set; }
    public  DbSet<FreeOrSpend> FreeOrSpend {  get; set; }
    public  DbSet<Groups> Groups {  get; set; }
    public  DbSet<Load> Load {  get; set; }
    public  DbSet<Nagruzka> Nagruzka {  get; set; }
    public  DbSet<ObuchenieForm> ObuchenieForm {  get; set; }
    public  DbSet<Plan> Plan {  get; set; }
    public  DbSet<Teachers> Teachers {  get; set; }
    public  DbSet<Specialize> Specializes {  get; set; }
    public  DbSet<Users> Users {  get; set; }
    
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;
        }

       
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=ProjectDB;Trusted_Connection=True;",
                options => 
                {
                    options.EnableRetryOnFailure(); 
                    options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                }
            );
        }
    }
}