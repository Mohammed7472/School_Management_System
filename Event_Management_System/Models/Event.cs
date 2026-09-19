using System.ComponentModel.DataAnnotations;

namespace Event_Management_System.Models;

public class Event
{
    public int Id { get; set; }

    [Required, MaxLength(99)]
    public string Title { get; set; }

    [Required, MaxLength(499)]
    public string Description { get; set; }

    [Required]
    public DateTime EventDate { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    [Required, MaxLength(50)]
    public string Category { get; set; }

    [Range(1, 10000)]
    public int Capacity { get; set; }

    public int OrganizerId { get; set; }
    public int VenueId { get; set; }
    public Organizer Organizer { get; set; }
    public Venue Venue { get; set; }
    public ICollection<Registration> Registrations
        = new List<Registration>();
}
