using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibrus.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cibrus.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SubjectController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _context.subjects;

            if (subjects == null)
            {
                return BadRequest(new { message = "not found" });
            }
            return Ok(subjects);
        }
    }
}