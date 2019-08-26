using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibrus.Context;
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
                .Include(g => g.Teacher)
                .Include(g => g.Student)
                .Where(b => b.StudentId.Equals(id));

            if (grades == null)
            {
                return BadRequest(new { message = "not found" });
            }
            return Ok(grades);
        }
    }
}