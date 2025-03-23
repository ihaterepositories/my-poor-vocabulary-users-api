namespace Data.Models;

public class StudentGameProgressAnalytic
{
    public Guid StudentId { get; set; }
    public int GamesCompleted { get; set; }
    public float AverageScorePerGame { get; set; }
    
    public Student Student { get; set; } = null!;
}