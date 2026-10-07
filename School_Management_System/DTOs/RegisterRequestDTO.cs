using System.ComponentModel.DataAnnotations;

namespace School_Management_System.DTOs;

public class RegisterRequestDTO
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(150), EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
