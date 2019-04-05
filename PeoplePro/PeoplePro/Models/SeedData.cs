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
                if (context.Employee.Any() && context.Department.Any() && context.Building.Any())
                {
                    return;   // DB has been seeded
                }

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

                context.Department.AddRange(
                   new Department
                   {
                       Name = "Mushroom",
                       BuildingID = 21
                   },
                   new Department
                   {
                       Name = "Hyrule",
                       BuildingID = 22
                   },
                   new Department
                   {
                       Name = "Dream Land",
                       BuildingID = 21
                   }
                );

                context.Employee.AddRange(
                    new Employee
                    {
                        ID = 1,
                        FirstName = "Luigi",
                        DepartmentID = 15,
                        BuildingID = 21
                    },

                    new Employee
                    {
                        ID = 2,
                        FirstName = "Link",
                        DepartmentID = 16,
                        BuildingID = 22
                    },

                    new Employee
                    {
                        ID = 3,
                        FirstName = "Tetra",
                        DepartmentID = 16,
                        BuildingID = 22
                    },

                    new Employee
                    {
                        ID = 4,
                        FirstName = "Kirby",
                        DepartmentID = 17,
                        BuildingID = 21
                    }
                );

                
                context.SaveChanges();
            }
        }
    }
}