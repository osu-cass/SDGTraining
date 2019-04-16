using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PeoplePro.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePro.Dal.Interfaces
{
    public interface IPeopleProContext : IDisposable
    {
        DbSet<Employee> Employees { get; set; }

        int SaveChanges();
        EntityEntry Entry(object entity);
    }
}
