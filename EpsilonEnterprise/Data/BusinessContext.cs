using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EpsilonEnterprise.Models;

namespace EpsilonEnterprise.Data
{
    public class BusinessContext : DbContext
    {
        public BusinessContext (DbContextOptions<BusinessContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Boss> Boss { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<AssignmentAssignment> AssignmentAssignment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Boss>().ToTable("Boss");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<AssignmentAssignment>().ToTable("AssignmentAssignment");

            modelBuilder.Entity<AssignmentAssignment>()
                .HasKey(c => new { c.AssignmentID, c.BossID });
        }
        
        public DbSet<EpsilonEnterprise.Models.Employee> Employee { get; set; }
    }
}
