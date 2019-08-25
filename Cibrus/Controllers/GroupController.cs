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
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GroupController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllGroups()
        {
            var groups = _context.groups;

            if (groups == null)
            {
                return BadRequest(new { message = "not found" });
            }
            return Ok(groups);
        }

        [HttpGet("group/{id}")]
        public IActionResult GetGroupById(int id)
        {
            var group = _context.groups
                .Where(b => b.GroupId.Equals(id));

            if (group == null)
            {
                return BadRequest(new { message = "not found" });
            }
            return Ok(group);
        }


    }
}