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
                // Look for any movies.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        Department = "CASS",
                        Building = "MCC-209",
                        FirstName = "Emily"
                    },
                    new Employee
                    {
                        Department = "CASS",
                        Building = "MCC-209",
                        FirstName = "Phi"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}