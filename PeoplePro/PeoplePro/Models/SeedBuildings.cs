using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PeoplePro.Models
{
    public static class SeedBuildings
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleProContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeopleProContext>>()))
            {
                // Look for any Employee/Department/ID.
                if (context.Building.Any())
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

                
                context.SaveChanges();
            }
        }
    }
}