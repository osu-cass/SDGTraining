using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace PeoplePro.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleProContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeopleProContext>>()))
            {
                // only seed these sample employees if DB has none
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee {
                            FirstName = "John",
                            LastName = "Doe",
                            Age = 42,
                            DepartmentId = 1
                        },
                        new Employee {
                            FirstName = "Jane",
                            LastName = "Doe",
                            Age = 39,
                            DepartmentId = 1
                        },
                        new Employee {
                            FirstName = "Carlton",
                            LastName = "Smith",
                            Age = 36,
                            DepartmentId = 2
                        },
                        new Employee {
                            FirstName = "Diana",
                            LastName = "Burnwood",
                            Age = 48,
                            DepartmentId = 3
                        }
                    );
                }

                // only seed these sample departments if DB has none
                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(
                        new Department {
                            Name = "Mathematics",
                            BuildingId = 1
                        },
                        new Department {
                            Name = "Electrical Engineering",
                            BuildingId = 2
                        },
                        new Department {
                            Name = "Computer Science",
                            BuildingId = 2
                        },
                        new Department {
                            Name = "Mechanical Engineering",
                            BuildingId = 3
                        }
                    );
                }

                // only seed these sample buildings if DB has none
                if (!context.Buildings.Any())
                {
                    context.Buildings.AddRange(
                        new Building {
                            Name = "Kidder Hall"
                        },
                        new Building {
                            Name = "Kelly Engineering Center"
                        },
                        new Building {
                            Name = "Rogers Hall"
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
