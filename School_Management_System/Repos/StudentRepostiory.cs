using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using School_Management_System.Data;
using School_Management_System.DTOs;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;

namespace School_Management_System.Repos;

public class StudentRepostiory : GenericRepo<Student>, IStudentRepository
{
    private readonly AppDbContext context;

    public StudentRepostiory(AppDbContext context) : base(context)
    {
        this.context = context;
    }

    public List<Student> GetByClassroom(int classroomId)
    {
        return context.Students
            .Where(s => s.ClassRoomId == classroomId)
            .ToList();
    }
}
