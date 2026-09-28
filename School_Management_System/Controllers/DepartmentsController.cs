using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Management_System.Data;
using School_Management_System.Models;
using School_Management_System.Repos.Abstraction;

namespace School_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IGenericRepo<Department> _repo;

    public DepartmentsController(IGenericRepo<Department> repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repo.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_repo.GetById(id));
    }

    [HttpPost]
    public IActionResult Create(Department dept)
    {
        _repo.Create(dept);
        _repo.Save();
        return CreatedAtAction(nameof(GetById), new { id = dept.Id }, dept);
    }

    [HttpPut]
    public IActionResult Update(Department dept)
    {
        _repo.Update(dept);
        _repo.Save();
        return NoContent();
    }
    [HttpDelete]
    public IActionResult Update(int id)
    {
        _repo.Delete(id);
        _repo.Save();
        return NoContent();
    }
}
