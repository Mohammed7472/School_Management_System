using School_Management_System.DTOs;
using School_Management_System.Models;

namespace School_Management_System.Repos.Abstraction;

public interface IStudentRepository : IGenericRepo<Student>
{
    List<Student> SearchByClassroom(int classroomId);
}
