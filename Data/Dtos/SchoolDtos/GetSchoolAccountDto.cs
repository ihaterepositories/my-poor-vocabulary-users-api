using Data.Dtos.StudentDtos;
using Data.Dtos.TeacherDtos;

namespace Data.Dtos.SchoolDtos;

public class GetSchoolAccountDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;

    public List<GetTeacherCredentialsDto> SchoolTeachersCredentials { get; set; } = [];
    public List<GetStudentCredentialsDto> SchoolStudentsCredentials { get; set; } = [];
}