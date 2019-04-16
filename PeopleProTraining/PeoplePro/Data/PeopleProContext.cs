using Microsoft.EntityFrameworkCore;

namespace PeoplePro.Models
{
    public class PeopleProContext : DbContext
    {
        public PeopleProContext(DbContextOptions<PeopleProContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Building> Buildings { get; set; }
    }
}
