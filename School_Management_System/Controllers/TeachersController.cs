using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;

namespace School_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{

    private readonly AppDbContext _context;
    public TeachersController()
    {
        _context = new AppDbContext();
    }

    [HttpGet("test-sum")]
    public IActionResult GetTotalSalaries()
    {
        var result = _context.Teachers
            .Sum(t => t.Salary);

        return Ok(result);
    }
}
