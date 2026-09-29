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

    public IGenericRepo<Subject> Subjects { get; }

    public IGenericRepo<Enrollment> Enrollments { get; }


    public UnitOfWork(AppDbContext context, IStudentRepository students,
        IGenericRepo<Department> departments, IGenericRepo<Teacher> teachers,
        IGenericRepo<ClassRoom> classrooms, IGenericRepo<Enrollment> enrollments,
        IGenericRepo<Subject> subjects)
    {
        this.context = context;
        Students = students;
        Teachers = teachers;
        Departments = departments;
        Classrooms = classrooms;
        Enrollments = enrollments;
        Subjects = subjects;
    }

    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
