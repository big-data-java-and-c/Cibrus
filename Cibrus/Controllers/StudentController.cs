using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cibrus.Context;
using Cibrus.models;

namespace Cibrus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StudentController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        //    @RequestMapping(method = RequestMethod.GET, path = "/student/{id}")
        // GET: api/Student/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Student>> GetStudent(int id)
        public IActionResult GetStudent(int id)
        {
            //var student = await _context.Students.FindAsync(id);

            var student = _context.Students
                .Include(g => g.User)
                .Include(u => u.Group)
                .Where(b => b.StudentId.Equals(id))
                .FirstOrDefault();

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //  @RequestMapping(method = RequestMethod.POST, path = "/student/add")
        // POST: api/Student
        [HttpPost("add")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }


        // @GetMapping("/student/group/{id}")
        // @GetMapping("/student/user/{id}")

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}