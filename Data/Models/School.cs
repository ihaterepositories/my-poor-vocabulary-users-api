using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Models;

public class School
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public string KeyForEnrollment { get; set; } = null!;

    public List<Teacher> Teachers { get; set; } = [];
    public List<Student> Students { get; set; } = [];
    
    // created to avoid null return
    [NotMapped] [JsonIgnore]
    public bool IsEmpty { get; private set; }
    public static School GetEmpty() => new() { IsEmpty = true };
}