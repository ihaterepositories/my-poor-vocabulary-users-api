namespace Data.Models;

public class StudentActivity
{
    public Guid StudentId { get; set; }
    public DateTime LastVisitation { get; set; }
    
    public Student? Student { get; set; } = null!;
}