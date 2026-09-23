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

        #region Pagination

        [HttpGet("pagination")]
        public IActionResult GetPaginatedData(int pageNumber = 1, int pageSize = 4)
        {
            var result = _context.Students
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = $"{s.FirstName} {s.LastName}",
                    Email = s.Email,
                    Phone = s.PhoneNumber,
                    ClassroomName = s.Classroom.Name,
                })
                .ToList();

            return Ok(result);
        }
        #endregion

        #region Custom_Endpoints(LINQ_Session)
        [HttpGet("filter")]
        public ActionResult<List<StudentDTO>> GetStudents(
            [FromQuery] int classRoomId,
        [FromQuery] int gradeLevel)
        {
            var students = _context.Students
                .Include(s => s.Classroom)
                .Where(s => s.ClassRoomId == classRoomId
                && s.Classroom.GradeLevel == gradeLevel)
                .ToList();

            var result = _mapper.Map<List<StudentDTO>>(students);

            return result;
        }

        [HttpGet("first")]
        public ActionResult<StudentDetailsDTO> GetFirstStudents(
            [FromQuery] int classRoomId)
        {
            var student = _context.Students
                .Include(s => s.Classroom)
                .First(s => s.ClassRoomId == classRoomId);

            var result = _mapper.Map<StudentDetailsDTO>(student);

            return result;
        }

        // Grouping Operators
        [HttpGet("students-per-classroom")]
        public IActionResult GetStudentCountPerClassroom()
        {
            var result = _context.Students
                .GroupBy(s => s.ClassRoomId)
                .Select(g => new { classroomId = g.Key, count = g.Count() })
                .ToList();

            return Ok(result);
        }

        // Set Operators
        [HttpGet("unique-classrooms")]
        public IActionResult GetUniqueClassrooms()
        {
            var classrooms = _context.Students
                .Select(s => s.ClassRoomId)
                .Distinct()
                .ToList();

            return Ok(classrooms);
        }

        [HttpGet("union-example")]
        public IActionResult UnionExample()
        {
            var group1 = _context.Students
                .Where(s => s.ClassRoomId == 1)
                .Select(s => s.FirstName);

            var group2 = _context.Students
                .Where(s => s.ClassRoomId == 2)
                .Select(s => s.FirstName);

            var result = group1.Union(group2)
                        .ToList();

            return Ok(result);
        }

        [HttpGet("intersect-example")]
        public IActionResult IntersectExample()
        {
            var group1 = _context.Students
                .Where(s => s.ClassRoomId == 1)
                .Select(s => s.FirstName);

            var group2 = _context.Students
                .Where(s => s.ClassRoomId == 2)
                .Select(s => s.FirstName);

            var result = group1.Intersect(group2)
                        .ToList();

            return Ok(result);
        }

        [HttpGet("except-example")]
        public IActionResult ExceptExample()
        {
            var group1 = _context.Students
                .Where(s => s.ClassRoomId == 1)
                .Select(s => s.FirstName);

            var group2 = _context.Students
                .Where(s => s.ClassRoomId == 2)
                .Select(s => s.FirstName);

            var result = group1.Except(group2)
                        .ToList();

            return Ok(result);
        }


        // Join Operators
        [HttpGet("student-classrooms")]
        public IActionResult GetStudentClassrooms()
        {
            var result = _context.Students
                .Join(_context.Classrooms, std => std.ClassRoomId,
                cls => cls.Id, (s, c) => new
                {
                    StudentName = $"{s.FirstName} {s.LastName}",
                    ClassroomName = c.Name
                }).ToList();

            return Ok(result);
        }

        [HttpGet("departments-with-students")]
        public IActionResult GetClassroomWithStudents()
        {
            var result = _context.Classrooms.GroupJoin(
          _context.Students,

          cls => cls.Id,
          student => student.ClassRoomId,

          (dept, stds) => new
          {
             ClassroomName = dept.Name,

             Students = stds.Select(s => new { s.FirstName, s.LastName })
          }
                );

            return Ok(result);
        }

        // Aggregate 
        [HttpGet("all-names")]
        public IActionResult GetAllNames()
        {
            var result = _context.Students
                .Select(s => s.FirstName)
                .ToList()
                 .Aggregate((a, b) => a + ", " + b);

            return Ok(result);
        }


        #endregion

        #region Main_endpoints
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
        #endregion
    }
}
