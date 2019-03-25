using Microsoft.EntityFrameworkCore;
using PeoplePro.Dal.Interfaces;
using PeoplePro.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePro.Dal.Infrastructure
{
    public class PeopleProContext : DbContext, IPeopleProContext
    {
        public PeopleProContext(DbContextOptions<PeopleProContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
