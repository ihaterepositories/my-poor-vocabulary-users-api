using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    
    public Guid SchoolId { get; set; }
    public School? School { get; set; }
    
    public Guid TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    
    public StudentActivity StudentActivity { get; set; } = null!;
    public StudentVocabularyAnalytic StudentVocabularyAnalytic { get; set; } = null!;
    public StudentGameProgressAnalytic StudentGameProgressAnalytic { get; set; } = null!;
    
    // created to avoid null return
    [NotMapped] [JsonIgnore]
    public bool IsEmpty { get; private set; }
    public static Student GetEmpty() => new() { IsEmpty = true };
}