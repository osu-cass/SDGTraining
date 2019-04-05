using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PeoplePro.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleProContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeopleProContext>>()))
            {
                // Look for any Employee.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                if (context.Building.Any())
                {
                    return;
                }

                context.Building.AddRange(
                    new Building
                    {
                        Name = "Temple",
                        DepartmentID = 1
                    }
                );

                context.Employee.AddRange(
                    new Employee
                    {
                        FirstName = "Luigi",
                        DepartmentID = 1,
                        BuildingID = 1
                    },

                    new Employee
                    {
                        FirstName = "Robin",
                        DepartmentID = 2,
                        BuildingID = 1
                    },

                    new Employee
                    {
                        FirstName = "Tetra",
                        DepartmentID = 2,
                        BuildingID = 1
                    },

                    new Employee
                    {
                        FirstName = "Roy",
                        DepartmentID = 3,
                        BuildingID = 3
                    }
                );


                context.SaveChanges();
            }
        }
    }
}