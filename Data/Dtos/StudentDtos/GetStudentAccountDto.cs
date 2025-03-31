using Data.Dtos.SchoolDtos;
using Data.Dtos.TeacherDtos;

namespace Data.Dtos.StudentDtos;

public class GetStudentAccountDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    
    public DateTime LastVisitation { get; set; }
    
    public int GamesCompleted { get; set; }
    public float AverageScorePerGame { get; set; }
    
    public int WordsCountInVocabulary { get; set; }
    public DateTime LastVocabularyUpdate { get; set; }
    
    public GetSchoolCredentialsDto SchoolCredentials { get; set; } = null!;
    public GetTeacherCredentialsDto TeacherCredentials { get; set; } = null!;
}