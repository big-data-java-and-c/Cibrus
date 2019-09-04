using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibrus.Context;
using Cibrus.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cibrus.Controllers
{
    [Route("api/grade")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GradesController(DatabaseContext context)
        {
           _context = context;
        }

        [HttpGet("all/{id}")]
        public IActionResult GetAllStudentsGrade(int id)
        {
            var grades = _context.grades
                .Include(g => g.Subject)
                .Include(g => g.Teacher.User)
                .Include(g => g.Student.Group)
                .Include(g => g.Student.User)
                .Where(b => b.StudentId.Equals(id));
          
            if (grades == null)
            {
                return BadRequest(new { message = "not found" });
            }
            return Ok(grades);
        }

        [HttpGet("grades/{subject_id}/student/{student_id}")]
        public IActionResult getGradesBySubjaectIdAndStudentId(int subject_id, int student_id)
        {

            var grades = _context.grades
           //.Include(g => g.Subject)
           .Where(c => c.SubjectId.Equals(subject_id))
          // .Include(g => g.Teacher.User)
          // .Include(g => g.Student.Group)
           //.Include(g => g.Student.User)
           .Where(b => b.StudentId.Equals(student_id));


            if (grades == null)
            {
                return BadRequest(new { message = "not found" });
            }
            return Ok(grades);
        }

        [HttpDelete("delete/{grade_id}")]
        public IActionResult deleteGradeById(int grade_id)
        {
            var grade = _context.grades
                .Where(b => b.GradeId.Equals(grade_id))
                .FirstOrDefault();

            if (grade == null)
            {
                return BadRequest(new { message = "not found" });
            }
            _context.grades.Remove(grade);
            _context.SaveChanges();

            return Ok();
        }

    }
}