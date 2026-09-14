namespace School_Management_System.Models
{
    public class Student_Subject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
