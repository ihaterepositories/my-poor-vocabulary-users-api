namespace Data.Dtos.TeacherDtos;

public class CreateTeacherDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DateOfBirthUnformatted { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string KeyForEnrollment { get; set; } = null!;
    public string SchoolKeyForEnrollment { get; set; } = null!;
}