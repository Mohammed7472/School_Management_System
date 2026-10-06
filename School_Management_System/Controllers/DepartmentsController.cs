using Microsoft.AspNetCore.Mvc;
using School_Management_System.Models;
using School_Management_System.UnitWork;

namespace School_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public DepartmentsController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = unitOfWork.Departments.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(unitOfWork.Departments.GetById(id));
    }

    [HttpPost]
    public IActionResult Create(Department dept)
    {
        unitOfWork.Departments.Create(dept);
        unitOfWork.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = dept.Id }, dept);
    }

    [HttpPut]
    public IActionResult Update(Department dept)
    {
        unitOfWork.Departments.Update(dept);
        unitOfWork.SaveChanges();
        return NoContent();
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        unitOfWork.Departments.Delete(id);
        unitOfWork.SaveChanges();
        return NoContent();
    }
}
