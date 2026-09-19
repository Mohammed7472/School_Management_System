using System.ComponentModel.DataAnnotations;

namespace Event_Management_System.Models;

public class Organizer
{
    public int Id { get; set; }

    [Required, MaxLength(99)]
    public string FullName { get; set; }

    [Required, EmailAddress, MaxLength(149)]
    public string Email { get; set; }

    [Required, Phone]
    public string Phone { get; set; }

    public ICollection<Event> Events
        = new List<Event>();
}
