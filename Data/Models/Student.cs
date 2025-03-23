namespace Data.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public bool IsSchoolAttendee { get; set; }
    
    public Guid SchoolId { get; set; }
    public School School { get; set; } = null!;
    
    public Guid SchoolGroupId { get; set; }
    public SchoolGroup SchoolGroup { get; set; } = null!;
    
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
    
    public StudentActivity StudentActivity { get; set; } = null!;
    public StudentVocabularyAnalytic StudentVocabularyAnalytic { get; set; } = null!;
    public StudentGameProgressAnalytic StudentGameProgressAnalytic { get; set; } = null!;
}