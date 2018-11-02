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
    public class DepartmentsControllerTests 
    { 
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new DepartmentsController();
            var result = controller.Index() as ViewResult;
            var departments = (ICollection<Department>) result.ViewData.Model;
            Assert.AreEqual("College of Engineering", departments.First().Name);
        }

        [TestMethod()]
        public void DetailsTestEmployees()
        {
            var controller = new DepartmentsController();
            var result = controller.Details(1) as ViewResult;
            var department = (Department) result.ViewData.Model;
            Assert.AreEqual("Drew", department.Employees.ToArray()[0].FirstName);
        }
        
        [TestMethod()]
        public void DetailsTestBuildings()
        {
            var controller = new DepartmentsController();
            var result = controller.Details(1) as ViewResult;
            var department = (Department) result.ViewData.Model;
            Assert.AreEqual("Kelley Engineering Center", department.Buildings.ToArray()[0].Name);
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
            var newDepartment = new Department();
            newDepartment.Name = "TestDepartmentName";

            var controller = new DepartmentsController();
            controller.Create(newDepartment);
            var result = controller.Index() as ViewResult;
            var departments = (ICollection<Department>)result.ViewData.Model;
            Assert.AreEqual("TestDepartmentName", departments.Last().Name); 
        }
        public void EditTest()
        {
            var controller = new DepartmentsController();
            var result = controller.Index() as ViewResult;
            var departments = (ICollection<Department>)result.ViewData.Model;
            var editDepartment = departments.Last();
            editDepartment.Name = "NewDepartmentName";
            controller.Edit(editDepartment);

            var result2 = controller.Index() as ViewResult;
            var departments2 = (ICollection<Department>)result2.ViewData.Model;
            Assert.AreEqual("NewDepartmentName", departments2.Last().Name);
        }
        public void DeleteTest()
        {
            var controller = new DepartmentsController();
            var result = controller.Index() as ViewResult;
            var departments = (ICollection<Department>)result.ViewData.Model;
            var Id = departments.Last().DepartmentId;
            controller.DeleteConfirmed(Id);

            var result2 = controller.Index() as ViewResult;
            var departments2 = (ICollection<Department>)result.ViewData.Model;
            Assert.AreNotEqual(Id, departments2.Last().DepartmentId);
        }
    }
}