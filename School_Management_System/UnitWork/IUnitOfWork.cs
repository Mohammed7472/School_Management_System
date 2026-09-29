using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;

namespace School_Management_System.UnitWork;

public interface IUnitOfWork
{
    public IStudentRepository Students { get; }
    public IGenericRepo<Teacher> Teachers { get; }
    public IGenericRepo<Department> Departments { get; }
    public IGenericRepo<ClassRoom> Classrooms { get; }
    public IGenericRepo<Subject> Subjects { get; }
    public IGenericRepo<Enrollment> Enrollments { get; }
    int SaveChanges();
}
