using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.DTOs;
using School_Management_System.Mappings;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController()
        {
            _context = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<StudentProfile>();
            });

            _mapper = config.CreateMapper();
        }

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetStudents()
        {
            var students = _context.Students
                .Include(s => s.Classroom)
                .ToList();

            var result = _mapper.Map<List<StudentDTO>>(students);

            return result;
        }

        [HttpGet("{id:int}")]
        public ActionResult<StudentDetailsDTO> GetStudentById([FromRoute] int id)
        {
            var student = _context.Students
                .Include(s => s.Classroom)
               .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<StudentDetailsDTO>(student);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDTO s)
        {
            if (s == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = _mapper.Map<Student>(s);

            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, s);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStudentDTO s)
        {
            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
                return BadRequest(new { message = $"Student with id={id} not found!" });

            _mapper.Map(s, existingStudent);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, string lastname)
        {
            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
                return BadRequest(new { message = $"Student with id={id} not found!" });

            existingStudent.LastName = lastname;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
                return NotFound();

            _context.Students.Remove(existingStudent);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
