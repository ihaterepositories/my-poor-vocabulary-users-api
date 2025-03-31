namespace Data.Dtos.TeacherDtos;

public class GetTeacherCredentialsDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;
}