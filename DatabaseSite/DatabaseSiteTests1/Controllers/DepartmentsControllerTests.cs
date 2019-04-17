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
    public class DepartmentsTestController : Controller
    {
        private PeopleProDatabaseEntities db = new PeopleProDatabaseEntities();
        // GET: DepartmentsTest
        [TestMethod]
        public void TestIndex()
        {
            var controller = new DepartmentsController();
            var res = controller.Index() as ViewResult;
            Assert.AreEqual("Index", res.ViewName);
        }

        [TestMethod]
        public void TestDetails()
        {
            //Existing department(for default db)
            var controller = new DepartmentsController();
            var good = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", good.ViewName);

            //Non-existent department
            var bad = controller.Details(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);

        }

        [TestMethod]
        public void TestEdit()
        {
            //Existing department(for deafult db)
            var controller = new DepartmentsController();
            var good = controller.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", good.ViewName);

            //Non-existent department
            var bad = controller.Edit(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);
        }

        [TestMethod]
        public void TestCreate()
        {
            var b = new Department();
            var controller = new DepartmentsController();

            b.Name = "Test";

            //Valid department
            var good = controller.Create(b) as RedirectToRouteResult;
            Assert.IsNotNull(good);
            //This seems like a bad way to do things, but...
            db.Departments.Remove(db.Departments.FirstOrDefault(i => i.Name == "Test"));
            db.SaveChanges();

            //Department with error
            controller.ModelState.AddModelError("test", "test");
            var bad = controller.Create(b) as ViewResult;
            Assert.AreEqual("Create", bad.ViewName);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Existing department(for deafult db)
            var controller = new DepartmentsController();
            var good = controller.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", good.ViewName);

            //Non-existent department
            var bad = controller.Delete(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);
        }
    }

}