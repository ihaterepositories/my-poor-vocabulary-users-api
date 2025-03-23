namespace Data.Models;

public class StudentVocabularyAnalytic
{
    public Guid StudentId { get; set; }
    public int WordsCount { get; set; }
    public DateTime LastUpdate { get; set; }
    
    public Student Student { get; set; } = null!;
}