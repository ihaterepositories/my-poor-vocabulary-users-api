namespace Data.Dtos.StudentDtos;

public class GetStudentProgressDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public DateTime LastVisitation { get; set; }
    public int GamesCompleted { get; set; }
    public float AverageScorePerGame { get; set; }
    public int WordsCountInVocabulary { get; set; }
    public DateTime LastVocabularyUpdate { get; set; }
}