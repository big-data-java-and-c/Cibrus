using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibrus.Context;
using Cibrus.models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cibrus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SubjectController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        //{
        

           
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(long id)
        {
            var todoItem = await _context.subjects.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}
