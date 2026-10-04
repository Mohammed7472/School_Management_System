using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;

namespace School_Management_System.UnitWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    public IStudentRepository Students { get; }

    public IGenericRepo<Teacher> Teachers { get; }

    public IGenericRepo<Department> Departments { get; }

    public IGenericRepo<ClassRoom> Classrooms { get; }
    public IGenericRepo<Enrollment> Enrollments { get; }

    public IGenericRepo<Subject> Subjects { get; }


    public UnitOfWork(AppDbContext context, IStudentRepository students,
    IGenericRepo<Teacher> teachers, IGenericRepo<Department> departments,
    IGenericRepo<Subject> subjects, IGenericRepo<Enrollment> enrollments,
    IGenericRepo<ClassRoom> classrooms)
    {
        this.context = context;
        Students = students;
        Teachers = teachers;
        Departments = departments;
        Enrollments = enrollments;
        Subjects = subjects;
        Classrooms = classrooms;
    }

    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
