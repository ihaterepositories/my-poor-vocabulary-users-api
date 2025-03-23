namespace Data.Models;

public class SchoolGroup
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string KeyForEnrollment { get; set; } = null!;
    
    public Guid SchoolId { get; set; }
    public School School { get; set; } = null!;

    public List<Student> Students { get; set; } = null!;
}