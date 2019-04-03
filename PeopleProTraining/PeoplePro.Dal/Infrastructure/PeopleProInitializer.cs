//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using Microsoft.EntityFrameworkCore;
//using PeoplePro.Dal.Interfaces;
//using PeoplePro.Dal.Models;

//namespace PeoplePro.Dal.Infrastructure
//{
//    public class PeopleProInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<PeopleProContext>
//    {
//        protected override void Seed(PeopleProContext context)
//        {
//            var employees = new List<Employee>
//            {
//                new Employee
//                {
//                    FirstName = "John",
//                    LastName = "Doe",
//                    Age = 42
//                },
//                new Employee
//                {
//                    FirstName = "Jane",
//                    LastName = "Doe",
//                    Age = 39
//                },
//                new Employee
//                {
//                    FirstName = "Carlton",
//                    LastName = "Smith",
//                    Age = 36
//                },
//                new Employee
//                {
//                    FirstName = "Diana",
//                    LastName = "Burnwood",
//                    Age = 48
//                }
//            };
//            employees.ForEach(e => context.Employees.Add(e));
//            context.SaveChanges();

//            var departments = new List<Department>
//            {
//                // put sample initial data here
//            };
//            departments.ForEach(d => context.Departments.Add(d));
//            context.SaveChanges();

//            var buildings = new List<Building>
//            {
//                // put sample initial data here
//            };
//            buildings.ForEach(b => context.Buildings.Add(b));
//            context.SaveChanges();
//        }
//    }
//}
