using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumberEnrollmentAssignment.pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumberEnrollmentAssignment.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private SchoolContext context;

        public CourseController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CoursePoco item)
        {
            context.Courses.Add(item);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            List<CoursePoco> res = context.Courses.ToList<CoursePoco>();
            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }

        [HttpGet("{Id}")]
        public IActionResult Read(int Id)
        {
            CoursePoco res = context.Courses.FirstOrDefault(a => a.Id == Id);
            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }

    }
}
