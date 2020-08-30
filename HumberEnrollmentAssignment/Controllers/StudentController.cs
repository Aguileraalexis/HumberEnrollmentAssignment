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
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private SchoolContext context;

        public StudentController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentPoco item)
        {
            context.Students.Add(item);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            List<StudentPoco> res = context.Students.ToList<StudentPoco>();
            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }

        [HttpGet("{Id}")]
        public IActionResult Read(int Id)
        {
            StudentPoco res = context.Students.FirstOrDefault(a => a.Id == Id);
            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }

    }
}
