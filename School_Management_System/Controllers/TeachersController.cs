using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;

namespace School_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{

    private readonly AppDbContext _context;
    public TeachersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllTeachers()
    {
        var result = _context.Teachers
            .ToList();

        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetTeacherDetails(int id)
    {
        var result = _context.Teachers
            .Select(t => new
            {
                Id = t.Id,
                Name = t.FirstName + " " + t.LastName,
                Phone = t.PhoneNumber,
                Salary = t.Salary.ToString("C2"),
                Deaprtment = t.Department.Name
            })
            .FirstOrDefault(t => t.Id == id);

        return Ok(result);
    }
}
