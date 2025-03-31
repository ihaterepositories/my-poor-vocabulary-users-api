namespace Data.Dtos.StudentDtos;

public class GetStudentCredentialsDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime RegistrationDate { get; set; }
}