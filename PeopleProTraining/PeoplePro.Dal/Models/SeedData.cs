using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using PeoplePro.Dal.Infrastructure;

namespace PeoplePro.Dal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleProContext(serviceProvider.GetRequiredService<DbContextOptions<PeopleProContext>>()))
            {
                // only seed these sample employees if DB has none
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                        new Employee
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            Age = 42
                        },
                        new Employee
                        {
                            FirstName = "Jane",
                            LastName = "Doe",
                            Age = 39
                        },
                        new Employee
                        {
                            FirstName = "Carlton",
                            LastName = "Smith",
                            Age = 36
                        },
                        new Employee
                        {
                            FirstName = "Diana",
                            LastName = "Burnwood",
                            Age = 48
                        }
                    );
                }


                
                context.SaveChanges();
            }
        }
    }
}
