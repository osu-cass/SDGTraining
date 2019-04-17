using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseSite.Controllers;
using DatabaseSite.Models;
using System.Net;
using System.Data.Entity;

namespace DatabaseSite.TestControllers
{
    [TestClass]
    public class EmployeesTestController : Controller
    {
        private PeopleProDatabaseEntities db = new PeopleProDatabaseEntities();
        // GET: EmployeesTest
        [TestMethod]
        public void TestIndex()
        {
            var controller = new EmployeesController();
            var res = controller.Index() as ViewResult;
            Assert.AreEqual("Index", res.ViewName);
        }

        [TestMethod]
        public void TestDetails()
        {
            //Existing employee(for default db)
            var controller = new EmployeesController();
            var good = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", good.ViewName);

            //Non-existent employee
            var bad = controller.Details(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);

        }

        [TestMethod]
        public void TestEdit()
        {
            //Existing employee(for deafult db)
            var controller = new EmployeesController();
            var good = controller.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", good.ViewName);

            //Non-existent employee
            var bad = controller.Edit(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);
        }

        [TestMethod]
        public void TestCreate()
        {
            var b = new Employee();
            var controller = new EmployeesController();

            //Valid employee
            b.FirstName = "Test";
            b.LastName = "Test";
            b.BuildingId = 1;
            b.DepartmentId = 1;
            var good = controller.Create(b) as RedirectToRouteResult;
            Assert.IsNotNull(good);
            //This seems like a bad way to do things, but...
            db.Employees.Remove(db.Employees.FirstOrDefault(i => i.FirstName == "Test" && i.LastName == "Test"));
            db.SaveChanges();

            //Employee with error
            controller.ModelState.AddModelError("test", "test");
            var bad = controller.Create(b) as ViewResult;
            Assert.AreEqual("Create", bad.ViewName);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Existing employee(for deafult db)
            var controller = new BuildingsController();
            var good = controller.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", good.ViewName);

            //Non-existent employee
            var bad = controller.Delete(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);
        }
    }

}