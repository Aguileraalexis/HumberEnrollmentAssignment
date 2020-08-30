using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumberEnrollmentAssignment.pocos
{
    public class EnrollmentPoco
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual StudentPoco Student { get; set; }
        public virtual CoursePoco Course { get; set; }

    }
}
