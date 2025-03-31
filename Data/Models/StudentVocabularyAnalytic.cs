namespace Data.Models;

public class StudentVocabularyAnalytic
{
    public Guid StudentId { get; set; }
    public int WordsCountInVocabulary { get; set; }
    public DateTime LastVocabularyUpdate { get; set; }
    
    public Student? Student { get; set; } = null!;
}