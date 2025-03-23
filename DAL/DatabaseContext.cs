using System.Reflection;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<School> Schools { get; set; }
    public DbSet<SchoolGroup> SchoolGroups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentActivity> StudentActivities { get; set; }
    public DbSet<StudentGameProgressAnalytic> StudentGameProgressAnalytics { get; set; }
    public DbSet<StudentVocabularyAnalytic> StudentVocabularyAnalytics { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}