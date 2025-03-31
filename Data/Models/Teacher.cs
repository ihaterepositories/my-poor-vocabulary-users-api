using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models;

public class Teacher
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;
    
    public Guid SchoolId { get; set; }
    public School? School { get; set; } 
    
    public List<Student> Students { get; set; } = [];
    
    // created to avoid null return
    [NotMapped] [JsonIgnore]
    public bool IsEmpty { get; private set; }
    public static Teacher GetEmpty() => new() { IsEmpty = true };
}