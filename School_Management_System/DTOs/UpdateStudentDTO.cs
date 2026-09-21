namespace School_Management_System.DTOs;

public class UpdateStudentDTO
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int ClassroomId { get; set; }
}
