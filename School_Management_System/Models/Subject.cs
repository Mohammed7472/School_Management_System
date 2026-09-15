using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(1, 100)]
        public int MaxGrade { get; set; }
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();
    }
}
