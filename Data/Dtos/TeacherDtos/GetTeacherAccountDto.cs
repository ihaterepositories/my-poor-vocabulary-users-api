using Data.Dtos.SchoolDtos;
using Data.Dtos.StudentDtos;
using Data.Models;

namespace Data.Dtos.TeacherDtos;

public class GetTeacherAccountDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;
    public GetSchoolCredentialsDto TeacherSchoolCredentials { get; set; } = null!;
    public List<GetStudentCredentialsDto> TeacherStudentsCredentials { get; set; } = [];
}