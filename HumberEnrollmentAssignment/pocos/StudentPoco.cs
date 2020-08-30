using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HumberEnrollmentAssignment.pocos
{
    public class StudentPoco
    {
        public StudentPoco()
        {
            this.Enrollments = new HashSet<EnrollmentPoco>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual HashSet<EnrollmentPoco> Enrollments { get; set; }
    }

}
