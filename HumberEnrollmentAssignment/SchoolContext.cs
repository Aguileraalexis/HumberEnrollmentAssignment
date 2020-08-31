using HumberEnrollmentAssignment.pocos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumberEnrollmentAssignment
{
    public class SchoolContext : DbContext
    {

        public SchoolContext()
        {
            
        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<StudentPoco> Students { get; set; }

        public DbSet<CoursePoco> Courses { get; set; }
        public DbSet<EnrollmentPoco> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnrollmentPoco>().HasKey(c => new { c.StudentId, c.CourseId });
            modelBuilder.Entity<EnrollmentPoco>().HasOne(e => e.Student).WithMany(e => e.Enrollments).HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<EnrollmentPoco>().HasOne(e => e.Course).WithMany(e => e.Enrollments).HasForeignKey(e => e.CourseId);
        }

    }

}
