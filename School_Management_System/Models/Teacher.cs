using System.ComponentModel.DataAnnotations;

namespace School_Management_System.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(20), Phone]
        public string? PhoneNumber { get; set; }

        [Required, Range(0, maximum: int.MaxValue)]
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Subject> Subjects { get; set; }
                = new List<Subject>();

    }
}
