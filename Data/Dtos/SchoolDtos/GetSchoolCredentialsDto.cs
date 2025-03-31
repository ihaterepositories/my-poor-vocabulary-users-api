namespace Data.Dtos.SchoolDtos;

public class GetSchoolCredentialsDto
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;
}