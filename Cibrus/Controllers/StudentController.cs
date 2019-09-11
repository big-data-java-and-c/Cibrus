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

        [HttpGet("group/{id}")]
        public IActionResult GetStudentsByGroupId(int id)
        {
            var students = _context.Students
                .Where(b => b.GroupId.Equals(id)); ;

            if (students == null)
            {
                return BadRequest(new { message = "not found" });
            }
            return Ok(students);
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
        /// <summary>
        /// ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        // studentidbyuserid
        [HttpGet("studentidbyuserid/{userId}")]
        public IActionResult getStudentIdByUserId(int userId)
        {
            int studentId = _context.Students
                 .Where(b => b.UserId.Equals(userId))
                 .FirstOrDefault()
                 .StudentId;

            return Ok(studentId);
        }

        // studentbystudentid
        [HttpGet("studentbystudentid/{studentId}")]
        public IActionResult getStudentByStudentId(int studentId)
        {
            var student = _context.Students
                 .Where(b => b.StudentId.Equals(studentId))
                 .FirstOrDefault();

            return Ok(student);
        }

        // studentbyuserid
        [HttpGet("studentbyuserid/{userId}")]
        public IActionResult getStudentByUserId(int userId)
        {
            int studentId = _context.Students
                    .Where(b => b.UserId.Equals(userId))
                    .FirstOrDefault()
                    .StudentId;

            var student = _context.Students
                 .Where(b => b.StudentId.Equals(studentId))
                 .FirstOrDefault();

            return Ok(student);
        }
        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        // PUT: api/Student/5
        [HttpPut("add")]
        public async Task<IActionResult> PutStudent(Student student)
        {
            

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentId))
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


        [HttpPost("{id}/setGroup/{selectedValue}")]
        public async Task<ActionResult<Student>> UpdateStudetnGroup(int id, int selectedValue )
        {
            Student student = _context.Students
                  .Where(b => b.StudentId.Equals(id))
                  .FirstOrDefault();
            Group group = _context.groups
                  .Where(b => b.GroupId.Equals(selectedValue))
                  .FirstOrDefault();

            student.Group = group;
            _context.Students.Update(student);
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