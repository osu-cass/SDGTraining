using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleProTraining.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using PeopleProTraining.Dal.Models;

namespace PeopleProTraining.Controllers.Tests
{
    [TestClass()]
    public class EmployeescontrollerTests 
    { 
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new EmployeesController();
            var result = controller.Index() as ViewResult;
            var employees = (ICollection<Employee>) result.ViewData.Model;
            Assert.AreEqual("Max", employees.ToArray()[1].FirstName);
        }

        [TestMethod()]
        public void DetailsTestFirstName()
        {
            var controller = new EmployeesController();
            var result = controller.Details(4) as ViewResult;
            var employee = (Employee) result.ViewData.Model;
            Assert.AreEqual("Drew", employee.FirstName);
        }

        [TestMethod()]
        public void DetailsTestLastName()
        {
            var controller = new EmployeesController();
            var result = controller.Details(4) as ViewResult;
            var employee = (Employee) result.ViewData.Model;
            Assert.AreEqual("Ortega", employee.LastName);
        }
        [TestMethod()]
        public void DetailsTestEmploymentDate()
        {
            var controller = new EmployeesController();
            var result = controller.Details(4) as ViewResult;
            var employee = (Employee)result.ViewData.Model;
            Assert.AreEqual("10/11/2018 12:00:00 AM", employee.EmploymentDate.ToString());
        }

        [TestMethod()]
        public void DetailsTestDepartment()
        {
            var controller = new EmployeesController();
            var result = controller.Details(4) as ViewResult;
            var employee = (Employee)result.ViewData.Model;
            Assert.AreEqual("College of Engineering", employee.Department.Name);
        }
        [TestMethod()]
        public void OrderedCRUDTest()
        {
            CreateTest();
            EditTest();
            DeleteTest();
        }
        public void CreateTest()
        { 
            var newEmployee = new Employee();
            newEmployee.FirstName = "TestEmployeeFName";
            newEmployee.LastName = "TestEmployeeLName";
            newEmployee.EmploymentDate = new DateTime(2017, 11, 11);
            newEmployee.DepartmentId = 1;

            var controller = new EmployeesController();
            controller.Create(newEmployee);
            var result = controller.Index() as ViewResult;
            var employees = (ICollection<Employee>)result.ViewData.Model;
            Assert.AreEqual("TestEmployeeFName", employees.Last().FirstName); 
        }
        public void EditTest()
        {
            var controller = new EmployeesController();
            var result = controller.Index() as ViewResult;
            var employees = (ICollection<Employee>)result.ViewData.Model;
            var editEmployee = employees.Last();
            editEmployee.FirstName = "NewEmployeeFName";
            editEmployee.LastName = "NewEmployeeLName";
            controller.Edit(editEmployee);

            var result2 = controller.Index() as ViewResult;
            var employees2 = (ICollection<Employee>)result2.ViewData.Model;
            Assert.AreEqual("NewEmployeeFName", employees2.Last().FirstName);
        }
        public void DeleteTest()
        {
            var controller = new EmployeesController();
            var result = controller.Index() as ViewResult;
            var employees = (ICollection<Employee>)result.ViewData.Model;
            var Id = employees.Last().EmployeeId;
            controller.DeleteConfirmed(Id);

            var result2 = controller.Index() as ViewResult;
            var employees2 = (ICollection<Employee>)result.ViewData.Model;
            Assert.AreNotEqual(Id, employees2.Last().EmployeeId);
        }
    }
}