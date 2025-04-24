namespace Data.Dtos.StudentDtos;

public class CreateStudentDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DateOfBirthUnformatted { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public string SchoolKeyForEnrollment { get; set; } = null!;
    public string TeacherKeyForEnrollment { get; set; } = null!;
}