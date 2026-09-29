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

    public List<Student> SearchByClassroom(int classroomId)
    {
        var result = context.Students
            .Where(s => s.ClassRoomId == classroomId)
            .ToList();
        return result;
    }





















    //public void Create(Student s)
    //{
    //    context.Students.Add(s);
    //}

    //public void Delete(int id)
    //{
    //    var existingStudent = context.Students.Find(id);

    //    if (existingStudent != null)
    //        context.Students.Remove(existingStudent);

    //}

    //public List<StudentDTO> GetAll()
    //{
    //    var result = context.Students.Select(s =>
    //     new StudentDTO
    //     {
    //         Id = s.Id,
    //         Email = s.Email,
    //         FullName = s.FirstName,
    //         PhoneNumber = s.PhoneNumber,
    //         ClassroomName = s.Classroom.Name
    //     }).ToList();

    //    return result;
    //}

    //public StudentDetailsDTO GetById(int id)
    //{
    //    var s = context.Students
    //        .Include(s => s.Classroom)
    //        .FirstOrDefault(s => s.Id == id);
    //    return new StudentDetailsDTO
    //    {
    //        Id = s.Id,
    //        Email = s.Email,
    //        FullName = s.FirstName,
    //        PhoneNumber = s.PhoneNumber,
    //        ClassroomName = s.Classroom.Name,
    //        GradeLevel = s.Classroom.GradeLevel,
    //    };

    //}



}
