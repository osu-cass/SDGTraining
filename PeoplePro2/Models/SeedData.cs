using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PeoplePro2.Models
{
    public static class SeedData
    {
        public static void InitializeBuildings(IServiceProvider serviceProvider)
        {
            using (var context = new PeoplePro2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeoplePro2Context>>()))
            {
                // Look for any buildings.
                if (context.Building.Any())
                {
                    return;   // DB has been seeded
                }

                context.Building.AddRange(
                    new Building
                    {
                        Name = "Peach Building"
                    },

                    new Building
                    {
                        Name = "Tangerine Building"
                    },

                    new Building
                    {
                        Name = "Mango Building"
                    }
                );
                context.SaveChanges();
            }
        }
        public static void InitializeDepartments(IServiceProvider serviceProvider)
        {
            using (var context = new PeoplePro2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeoplePro2Context>>()))
            {
                // Look for any buildings.
                if (context.Department.Any())
                {
                    return;   // DB has been seeded
                }

                context.Department.AddRange(
                    new Department
                    {
                        Name = "Tech Services",
                        BuildingId = context.Building.Skip(0).FirstOrDefault().BuildingId
                    },

                    new Department
                    {
                        Name = "Cafeteria",
                        BuildingId = context.Building.Skip(1).FirstOrDefault().BuildingId
                    },

                    new Department
                    {
                        Name = "Human Resources",
                        BuildingId = context.Building.Skip(2).FirstOrDefault().BuildingId
                    },

                    new Department
                    {
                        Name = "Marketing",
                        BuildingId = context.Building.Skip(1).FirstOrDefault().BuildingId
                    },

                    new Department
                    {
                        Name = "Billing",
                        BuildingId = context.Building.Skip(2).FirstOrDefault().BuildingId
                    }
                );
                context.SaveChanges();
            }
        }
        public static void InitializeEmployees(IServiceProvider serviceProvider)
        {
            using (var context = new PeoplePro2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeoplePro2Context>>()))
            {
                // Look for any buildings.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        FirstName = "Shannon",
                        DepartmentId = context.Department.Skip(0).FirstOrDefault().DepartmentId

                    },

                    new Employee
                    {
                        FirstName = "Marge",
                        DepartmentId = context.Department.Skip(2).FirstOrDefault().DepartmentId
                    },

                    new Employee
                    {
                        FirstName = "Jim",
                        DepartmentId = context.Department.Skip(4).FirstOrDefault().DepartmentId
                    },

                    new Employee
                    {
                        FirstName = "Karen",
                        DepartmentId = context.Department.Skip(1).FirstOrDefault().DepartmentId
                    },

                    new Employee
                    {
                        FirstName = "Pam",
                        DepartmentId = context.Department.Skip(2).FirstOrDefault().DepartmentId
                    },

                    new Employee
                    {
                        FirstName = "Michael",
                        DepartmentId = context.Department.Skip(1).FirstOrDefault().DepartmentId
                    },

                    new Employee
                    {
                        FirstName = "Dwight",
                        DepartmentId = context.Department.Skip(3).FirstOrDefault().DepartmentId
                    }
                );
                context.SaveChanges();
            }
        }
    }
}