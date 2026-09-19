using Event_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_System.Data;

public class AppDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Registration> Registrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Event_Management_System;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Duplicate registration prevention
        modelBuilder.Entity<Registration>()
            .HasIndex(r => new { r.AttendeeId, r.EventId })
            .IsUnique();

        // Relationships & Delete behavior
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Venue)
            .WithMany(v => v.Events)
            .HasForeignKey(v => v.VenueId);

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .HasForeignKey(r => r.EventId);

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Attendee)
            .WithMany(a => a.Registrations)
            .HasForeignKey(r => r.AttendeeId);


        // Unique Constraints 
        modelBuilder.Entity<Organizer>()
            .HasIndex(o => o.Email)
            .IsUnique();

        modelBuilder.Entity<Attendee>()
            .HasIndex(a => a.Email)
            .IsUnique();

        modelBuilder.Entity<Venue>()
            .HasIndex(v => v.Name)
            .IsUnique();

        // Seed Data
        // Organizers (3 records)
        modelBuilder.Entity<Organizer>().HasData(
            new Organizer
            {
                Id = 1,
                FullName = "Ahmed Mohamed",
                Email = "ahmed.mohamed@example.com",
                Phone = "+201001234567"
            },
            new Organizer
            {
                Id = 2,
                FullName = "Fatima Hassan",
                Email = "fatima.hassan@example.com",
                Phone = "+201101234567"
            },
            new Organizer
            {
                Id = 3,
                FullName = "Mohammed Ali",
                Email = "mohammed.ali@example.com",
                Phone = "+201201234567"
            }
        );

        // Venues (3 records)
        modelBuilder.Entity<Venue>().HasData(
            new Venue
            {
                Id = 1,
                Name = "Grand Convention Center",
                Location = "Cairo, Egypt",
                Capacity = 5000
            },
            new Venue
            {
                Id = 2,
                Name = "Marina Event Hall",
                Location = "Alexandria, Egypt",
                Capacity = 2000
            },
            new Venue
            {
                Id = 3,
                Name = "Giza Exhibition Complex",
                Location = "Giza, Egypt",
                Capacity = 3000
            }
        );

        // Events (5 records)
        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                Id = 1,
                Title = "Tech Conference 2025",
                Description = "Annual technology conference featuring latest innovations in AI and cloud computing",
                EventDate = new DateTime(2025, 3, 15),
                StartTime = new TimeSpan(9, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Category = "Technology",
                Capacity = 1000,
                OrganizerId = 1,
                VenueId = 1
            },
            new Event
            {
                Id = 2,
                Title = "Business Networking Summit",
                Description = "Exclusive networking event for business professionals and entrepreneurs",
                EventDate = new DateTime(2025, 4, 10),
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(18, 0, 0),
                Category = "Business",
                Capacity = 500,
                OrganizerId = 2,
                VenueId = 2
            },
            new Event
            {
                Id = 3,
                Title = "Digital Marketing Workshop",
                Description = "Intensive workshop on modern digital marketing strategies and tools",
                EventDate = new DateTime(2025, 5, 20),
                StartTime = new TimeSpan(8, 30, 0),
                EndTime = new TimeSpan(16, 30, 0),
                Category = "Marketing",
                Capacity = 300,
                OrganizerId = 1,
                VenueId = 3
            },
            new Event
            {
                Id = 4,
                Title = "Leadership Development Program",
                Description = "Comprehensive leadership training for mid-level and senior management",
                EventDate = new DateTime(2025, 6, 5),
                StartTime = new TimeSpan(9, 30, 0),
                EndTime = new TimeSpan(17, 30, 0),
                Category = "Training",
                Capacity = 200,
                OrganizerId = 3,
                VenueId = 1
            },
            new Event
            {
                Id = 5,
                Title = "Innovation Hackathon",
                Description = "48-hour hackathon for developers and innovators to build solutions",
                EventDate = new DateTime(2025, 7, 12),
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(20, 0, 0),
                Category = "Technology",
                Capacity = 400,
                OrganizerId = 2,
                VenueId = 2
            }
        );

        // Attendees (6 records)
        modelBuilder.Entity<Attendee>().HasData(
            new Attendee
            {
                Id = 1,
                FullName = "Karim Ibrahim",
                Email = "karim.ibrahim@example.com",
                Phone = "+201301234567"
            },
            new Attendee
            {
                Id = 2,
                FullName = "Layla Ahmad",
                Email = "layla.ahmad@example.com",
                Phone = "+201401234567"
            },
            new Attendee
            {
                Id = 3,
                FullName = "Omar Khaled",
                Email = "omar.khaled@example.com",
                Phone = "+201501234567"
            },
            new Attendee
            {
                Id = 4,
                FullName = "Noor Hassan",
                Email = "noor.hassan@example.com",
                Phone = "+201601234567"
            },
            new Attendee
            {
                Id = 5,
                FullName = "Salma Sayed",
                Email = "salma.sayed@example.com",
                Phone = "+201701234567"
            },
            new Attendee
            {
                Id = 6,
                FullName = "Hassan Amin",
                Email = "hassan.amin@example.com",
                Phone = "+201801234567"
            }
        );

        // Registrations (8 records)
        modelBuilder.Entity<Registration>().HasData(
            new Registration
            {
                Id = 1,
                EventId = 1,
                AttendeeId = 1,
                RegistrationDate = new DateTime(2025, 2, 1),
                Status = "Confirmed"
            },
            new Registration
            {
                Id = 2,
                EventId = 1,
                AttendeeId = 2,
                RegistrationDate = new DateTime(2025, 2, 5),
                Status = "Confirmed"
            },
            new Registration
            {
                Id = 3,
                EventId = 2,
                AttendeeId = 3,
                RegistrationDate = new DateTime(2025, 3, 1),
                Status = "Confirmed"
            },
            new Registration
            {
                Id = 4,
                EventId = 2,
                AttendeeId = 4,
                RegistrationDate = new DateTime(2025, 3, 10),
                Status = "Pending"
            },
            new Registration
            {
                Id = 5,
                EventId = 3,
                AttendeeId = 5,
                RegistrationDate = new DateTime(2025, 4, 15),
                Status = "Confirmed"
            },
            new Registration
            {
                Id = 6,
                EventId = 4,
                AttendeeId = 1,
                RegistrationDate = new DateTime(2025, 5, 1),
                Status = "Confirmed"
            },
            new Registration
            {
                Id = 7,
                EventId = 5,
                AttendeeId = 2,
                RegistrationDate = new DateTime(2025, 6, 1),
                Status = "Confirmed"
            },
            new Registration
            {
                Id = 8,
                EventId = 5,
                AttendeeId = 6,
                RegistrationDate = new DateTime(2025, 6, 15),
                Status = "Confirmed"
            }
        );

    }
}
