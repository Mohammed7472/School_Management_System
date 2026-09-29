using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    //[Index(nameof(StudentId), nameof(SubjectId), IsUnique = true)]
    public class Enrollment
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        [Range(0, 100)]
        public decimal Grade { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
