namespace Data.Dtos.SchoolDtos;

public class CreateSchoolDto
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string KeyForEnrollment { get; set; } = null!;
}