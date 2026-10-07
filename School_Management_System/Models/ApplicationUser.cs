using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models;

public class ApplicationUser
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(150), EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public string Role { get; set; } = "Student";  // Admin/Teacher/Student
}
