using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Repos;

public class DepartmentRepository
{
    private readonly AppDbContext context;

    public DepartmentRepository(AppDbContext context)
    {
        this.context = context;
    }
    public List<Department> GetAll()
    {
        return context.Departments.ToList();
    }
    public Department GetById(int id)
    {
        return context.Departments.Find(id);
    }

    public void Add(Department dept)
    {
        context.Departments.Add(dept);
        context.SaveChanges();
    }
    public void Update(Department dept)
    {
        context.Departments.Update(dept);
        context.SaveChanges();
        //context.Entry(dept).State = EntityState.Modified;
    }
    public void Delete(int id)
    {
        Department d = context.Departments.Find(id);
        context.Departments.Remove(d);
        context.SaveChanges();
    }
    //public int Save()
    //{
    //    return context.SaveChanges();
    //}
}
