namespace Data.Dtos.TeacherDtos;

public class GetTeacherStudyResultsDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;
    
    public int StudentsCount { get; set; }
    public double StudentsAverageWordsCountInVocabulary { get; set; }
    public double StudentsAverageGamesCompleted { get; set; }
    public int LastWeekActiveStudentsCount { get; set; }
}