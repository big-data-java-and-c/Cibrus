using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibrus.Context;
using Cibrus.models;
using Cibrus.Services;
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
        private IUserService userService;

        public GradesController(DatabaseContext context, IUserService _userService)
        {
           _context = context;
            userService = _userService;
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


        //to do add grade   url:http://localhost:8081/api/grade/add"
 
        [HttpPost("add")]
        public IActionResult register([FromBody] Grade gradeToSave)
        {

      // public Subject Subject { get; set; }
        Subject sub = new Subject();
            sub = (Subject)_context.subjects.Where(s => s.SubjectId.Equals(gradeToSave.SubjectId)).First();
   //     public Teacher Teacher { get; set; }
        Teacher ch = new Teacher();
             gradeToSave.TeacherId = _context.teachers.Where(abc => abc.UserId.Equals(gradeToSave.TeacherId)).First().id;
            //int techID = _context.teachers.Where(abc => abc.UserId.Equals(gradeToSave.TeacherId)).First().id;
            //int tech2ID = userService.getTeacherByID(gradeToSave.TeacherId).id;
           // Teacher tech3ID = _context.teachers                .Where(second => second.UserId.Equals(gradeToSave.TeacherId))                .FirstOrDefault();
            ch = (Teacher)_context.teachers.Where(c => c.id.Equals(gradeToSave.TeacherId)).First();
            ch.User = (User)_context.users.Where(u => u.UserId.Equals(ch.UserId)).First();
       // public Student Student { get; set; }
        Student st = new Student();
        st = (Student) _context.Students.Where(a => a.StudentId.Equals(gradeToSave.StudentId)).First();
            st.Group = (Group)_context.groups.Where(g => g.GroupId.Equals(st.GroupId)).First();
            st.User = (User)_context.users.Where(u => u.UserId.Equals(st.UserId)).First();
            //gradeToSave.Teacher = userService.getTeacherByID(gradeToSave.TeacherId);

            gradeToSave.Subject = sub;
            gradeToSave.Teacher = ch;
            gradeToSave.Student = st;

            if (gradeToSave != null)
            {
                 

                _context.grades.Add(gradeToSave);
                _context.SaveChanges();
 
                return Ok(gradeToSave); 
            }
            else { return BadRequest(new { message = " nie dodano uzytkownika" }); }
        }
         
      
    }
}