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
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {

        private SchoolContext context;

        public EnrollmentController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            List<EnrollmentPoco> res = context.Enrollments.ToList<EnrollmentPoco>();

            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] EnrollmentPoco item)
        {
            //this is to validate the exist
            StudentPoco student = context.Students.FirstOrDefault<StudentPoco>(a => a.Id == item.StudentId);
            CoursePoco course = context.Courses.FirstOrDefault<CoursePoco>(a => a.Id == item.CourseId);

             if (student != null && course != null)
            {

                context.Enrollments.Add(item);
                context.SaveChanges();
                return Ok();
            }
            else //either Student or Course not found, Can't create
            {
                return NotFound();
            }
        }

        [HttpDelete("{StudentId}/{CourseId}")]
        public IActionResult Delete(int StudentId, int CourseId)
        {
            EnrollmentPoco res = context.Enrollments.FirstOrDefault(a => a.StudentId == StudentId && a.CourseId == CourseId);

            if (res != null) 
            {
                context.Enrollments.Remove(res);
                context.SaveChanges();
                return Ok();
            }
            else
                return NotFound();
        }

    }
}
