using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeopleProTraining.Models;
using System.ComponentModel.DataAnnotations;

namespace PeopleProTraining.DAL
{
    public class PeopleProInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PeopleProContext>
    {
        protected override void Seed(PeopleProContext context)
        {
            var buildings = new List<Building>
            {
                new Building{Name="Kelley Engineering Center", Address="1 Campus Wy." },
                new Building{Name="Bexell Hall", Address="2 Campus Wy." },
                new Building{Name="Kidder Hall", Address="3 Campus Wy." }
            };

            buildings.ForEach(b => context.Buildings.Add(b));
            context.SaveChanges();
        }
    }
}