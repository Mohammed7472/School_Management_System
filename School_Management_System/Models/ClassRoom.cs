using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Range(1, 12)]
        public int GradeLevel { get; set; }

        [Range(1, 100)]
        public int Capacity { get; set; }

        public ICollection<Student> Students { get; set; }
            = new List<Student>();
    }
}
