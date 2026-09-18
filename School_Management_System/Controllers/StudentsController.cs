using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System.Data;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            var students = _context.Students
                .Include(s => s.ClassRoom)
                .ToList();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentById([FromRoute] int id)
        {
            var student = _context.Students
                .Include(s => s.ClassRoom)
               .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student s)
        {
            if (s == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Students.Add(s);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetStudentById), new { id = s.Id }, s);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student s)
        {
            if (s.Id != id)
                return BadRequest();

            var existingStudent = _context.Students.Find(id);

            if (existingStudent == null)
                return BadRequest(new { message = $"Student with id={id} not found!" });

            existingStudent.FirstName = s.FirstName;
            existingStudent.LastName = s.LastName;
            existingStudent.Email = s.Email;
            existingStudent.DateOfBirth = s.DateOfBirth;
            existingStudent.ClassRoomId = s.ClassRoomId;

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
