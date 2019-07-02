using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PeoplePro.Models
{
    public class SeedEmployees
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleProContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeopleProContext>>()))
            {
                // Look for any Employee/Department/ID.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        FirstName = "Luigi",
                        DepartmentID = context.Department.Skip(0).FirstOrDefault().ID,
                        BuildingID = context.Building.Skip(0).FirstOrDefault().ID
                    },

                    new Employee
                    {
                        FirstName = "Link",
                        DepartmentID = context.Department.Skip(1).FirstOrDefault().ID,
                        BuildingID = context.Building.Skip(1).FirstOrDefault().ID
                    },

                    new Employee
                    {
                        FirstName = "Tetra",
                        DepartmentID = context.Department.Skip(1).FirstOrDefault().ID,
                        BuildingID = context.Building.Skip(1).FirstOrDefault().ID
                    },

                    new Employee
                    {
                        FirstName = "Bowser",
                        DepartmentID = context.Department.Skip(2).FirstOrDefault().ID,
                        BuildingID = context.Building.Skip(0).FirstOrDefault().ID
                    }
                );


                context.SaveChanges();
            }
        }
    }
}
