//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;
//using System.Web;
//using System.Data.Entity;
//using PeoplePro.Dal.Infrastructure;
//using PeoplePro.Dal.Interfaces;

//namespace PeoplePro.Dal.Models
//{
//    class PeopleProInitializer : DropCreateDatabaseIfModelChanges<PeopleProContext>
//    {
//        protected override void Seed(PeopleProContext context)
//        {
//            var employees = new List<Employee>
//            {
//                new Employee
//                {
//                    FirstName = "John",
//                    LastName = "Doe",
//                    Age = 42,
//                    DepartmentId = 1
//                },
//                new Employee
//                {
//                    FirstName = "Jane",
//                    LastName = "Doe",
//                    Age = 39,
//                    DepartmentId = 1
//                },
//                new Employee
//                {
//                    FirstName = "Carlton",
//                    LastName = "Smith",
//                    Age = 36,
//                    DepartmentId = 2
//                },
//                new Employee
//                {
//                    FirstName = "Diana",
//                    LastName = "Burnwood",
//                    Age = 48,
//                    DepartmentId = 3
//                }
//            };
//            employees.ForEach(e => context.Employees.Add(e));
//            context.SaveChanges();

//            var departments = new List<Department>
//            {
//                new Department
//                {
//                    Name = "Mathematics",
//                    BuildingId = 1
//                },
//                new Department
//                {
//                    Name = "Electrical Engineering",
//                    BuildingId = 2
//                },
//                new Department
//                {
//                    Name = "Computer Science",
//                    BuildingId = 2
//                },
//                new Department
//                {
//                    Name = "Mechanical Engineering",
//                    BuildingId = 3
//                }
//            };
//            departments.ForEach(d => context.Departments.Add(d));
//            context.SaveChanges();

//            var buildings = new List<Building>
//            {
//                new Building
//                {
//                    Name = "Kidder Hall"
//                },
//                new Building
//                {
//                    Name = "Kelly Engineering Center"
//                },
//                new Building
//                {
//                    Name = "Rogers Hall"
//                }
//            };
//            buildings.ForEach(b => context.Buildings.Add(b));
//            context.SaveChanges();
//        }
//    }
//}
