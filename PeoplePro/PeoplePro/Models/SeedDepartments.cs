using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace PeoplePro.Models
{
    public class SeedDepartments
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleProContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PeopleProContext>>()))
            {
                // Look for any Deprtment.
                if (context.Department.Any())
                {
                    return;   // DB has been seeded
                }

                context.Department.AddRange(
                   new Department
                   {
                       Name = "Mushroom",
                       BuildingID = context.Building.Skip(0).FirstOrDefault().ID
                   },
                   new Department
                   {
                       Name = "Hyrule",
                       BuildingID = context.Building.Skip(1).FirstOrDefault().ID
                   },
                   new Department
                   {
                       Name = "Koopa",
                       BuildingID = context.Building.Skip(0).FirstOrDefault().ID
                   }
                );


                context.SaveChanges();
            }
        }
    }
}
