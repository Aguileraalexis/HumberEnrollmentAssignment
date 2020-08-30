using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HumberEnrollmentAssignment.pocos
{
    public class CoursePoco
    {
        public CoursePoco()
        {
            this.Enrollments = new HashSet<EnrollmentPoco>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual HashSet<EnrollmentPoco> Enrollments { get; set; }
    }
}
