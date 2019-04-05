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
                // Look for any Employee/Department/ID.
                if (context.Employee.Any() || context.Department.Any() || context.Department.Any())
                {
                    return;   // DB has been seeded
                }

                context.Department.AddRange(
                   new Department
                   {
                       Name = "Mushroom",
                       BuildingID = 1
                   },
                   new Department
                   {
                       Name = "Hyrule",
                       BuildingID = 2
                   },
                   new Department
                   {
                       Name = "Dream Land",
                       BuildingID = 1
                   }
                );

                context.Building.AddRange(
                    new Building
                    {
                        Name = "Castle",
                    },
                    new Building
                    {
                        Name = "Temple",
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
                        FirstName = "Link",
                        DepartmentID = 2,
                        BuildingID = 2
                    },

                    new Employee
                    {
                        FirstName = "Tetra",
                        DepartmentID = 2,
                        BuildingID = 2
                    },

                    new Employee
                    {
                        FirstName = "Kirby",
                        DepartmentID = 3,
                        BuildingID = 1
                    }
                );

                
                context.SaveChanges();
            }
        }
    }
}