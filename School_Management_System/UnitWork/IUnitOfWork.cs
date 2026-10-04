using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;

namespace School_Management_System.UnitWork;

public interface IUnitOfWork
{
    IStudentRepository Students { get; }
    IGenericRepo<Teacher> Teachers { get; }
    IGenericRepo<Department> Departments { get; }
    IGenericRepo<ClassRoom> Classrooms { get; }
    IGenericRepo<Enrollment> Enrollments { get; }
    IGenericRepo<Subject> Subjects { get; }

    int SaveChanges();
}
