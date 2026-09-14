using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [Phone, MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Student_Subject> Student_Subjects { get; set; } 
            = new List<Student_Subject>();
    }
}
