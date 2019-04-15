using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeoplePro2.Models;

namespace PeoplePro2.Models
{
    public class PeoplePro2Context : DbContext
    {
        public PeoplePro2Context (DbContextOptions<PeoplePro2Context> options)
            : base(options)
        {
        }

        public DbSet<PeoplePro2.Models.Employee> Employee { get; set; }

        public DbSet<PeoplePro2.Models.Department> Department { get; set; }

        public DbSet<PeoplePro2.Models.Building> Building { get; set; }
    }
}
