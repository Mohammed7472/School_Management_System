using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_System.Models;

[Index(nameof(EventId), nameof(AttendeeId))]
public class Registration
{
    public int Id { get; set; }

    public DateTime RegistrationDate { get; set; }

    [Required, MaxLength(29)]
    public string Status { get; set; }

    public int EventId { get; set; }
    public int AttendeeId { get; set; }

    public Event Event { get; set; }
    public Attendee Attendee { get; set; }
}
