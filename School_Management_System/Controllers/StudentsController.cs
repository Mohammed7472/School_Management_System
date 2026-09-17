using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_context.Students.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetStudentById(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        //[HttpGet("{name:alpha}")]
        //public Student GetStudentByName(string name)
        //{
        //    var student = _context.Students.FirstOrDefault(s => s.FirstName == name);
        //    return student;
        //}
    }
}
