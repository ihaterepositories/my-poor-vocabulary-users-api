namespace Data.Models;

public class School
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;
    
    public List<SchoolGroup> SchoolGroups { get; set; } = null!;
    public List<Teacher> Teachers { get; set; } = null!;
    public List<Student> Students { get; set; } = null!;
}