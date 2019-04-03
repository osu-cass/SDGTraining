using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeoplePro.Models;

namespace PeoplePro.Models
{
    public class PeopleProContext : DbContext
    {
        public PeopleProContext (DbContextOptions<PeopleProContext> options)
            : base(options)
        {
        }

        /**protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>().HasOne(e => e.Department).WithMany(d => d.Employees).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Employee>().HasOne(e => e.Building).WithMany(d => d.Employees).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Building>().HasMany(e => e.Departments).WithOne(d => d.DepartmentHQ).OnDelete(DeleteBehavior.SetNull);
        }**/

        public DbSet<PeoplePro.Models.Employee> Employee { get; set; }

        /**protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>().HasOne(e => e.Department).WithMany(d => d.Employees).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Employee>().HasOne(e => e.Building).WithMany(d => d.Employees).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Building>().HasMany(e => e.Departments).WithOne(d => d.DepartmentHQ).OnDelete(DeleteBehavior.SetNull);
        }**/

        public DbSet<PeoplePro.Models.Department> Department { get; set; }

        /**protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employee>().HasOne(e => e.Department).WithMany(d => d.Employees).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Employee>().HasOne(e => e.Building).WithMany(d => d.Employees).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Building>().HasMany(e => e.Departments).WithOne(d => d.DepartmentHQ).OnDelete(DeleteBehavior.SetNull);
        }**/

        public DbSet<PeoplePro.Models.Building> Building { get; set; }
    }
}
