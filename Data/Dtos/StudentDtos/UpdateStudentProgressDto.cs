namespace Data.Dtos.StudentDtos;

public class UpdateStudentProgressDto
{
    public Guid StudentId { get; set; }
    public int GamesCompleted { get; set; }
    public float AverageScorePerGame { get; set; }
    public int WordsCountInVocabulary { get; set; }
    public DateTime LastVocabularyUpdate { get; set; }
}