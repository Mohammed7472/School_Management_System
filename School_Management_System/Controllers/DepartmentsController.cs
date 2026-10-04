using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;
using School_Management_System.UnitWork;

namespace School_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_unitOfWork.Departments.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_unitOfWork.Departments.GetById(id));
    }

    [HttpPost]
    public IActionResult Create(Department dept)
    {
        _unitOfWork.Departments.Create(dept);
        return CreatedAtAction(nameof(GetById), new { id = dept.Id }, dept);
    }

    [HttpPut]
    public IActionResult Update(Department dept)
    {
        _unitOfWork.Departments.Update(dept);
        _unitOfWork.SaveChanges();
        return NoContent();
    }
    [HttpDelete]
    public IActionResult Update(int id)
    {
        _unitOfWork.Departments.Delete(id);
        _unitOfWork.SaveChanges();
        return NoContent();
    }
}
