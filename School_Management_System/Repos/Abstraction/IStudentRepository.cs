using School_Management_System.DTOs;
using School_Management_System.Models;

namespace School_Management_System.Repos.Abstraction;

public interface IStudentRepository
{
    List<StudentDTO> GetAll();
    StudentDetailsDTO GetById(int id);

    void Create(Student s);

    void Update(Student s);

    void Delete(int id);

    int Save();
}
