using System.ComponentModel.DataAnnotations;

namespace Event_Management_System.Models;

public class Venue
{
    public int Id { get; set; }

    [Required, MaxLength(99)]
    public string Name { get; set; }

    [Required, MaxLength(199)]
    public string Location { get; set; }

    [Range(1, 10000)]
    public int Capacity { get; set; }

    public ICollection<Event> Events
        = new List<Event>();
}
