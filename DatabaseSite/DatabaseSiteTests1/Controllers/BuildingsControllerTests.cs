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
    public class BuildingsTestController : Controller
    {
        private PeopleProDatabaseEntities db = new PeopleProDatabaseEntities();
        // GET: BuildingsTest
        [TestMethod]
        public void TestIndex()
        {
            var controller = new BuildingsController();
            var res = controller.Index() as ViewResult;
            Assert.AreEqual("Index", res.ViewName);
        }

        [TestMethod]
        public void TestDetails()
        {
            //Existing building(for default db)
            var controller = new BuildingsController();
            var good = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", good.ViewName);

            //Non-existent building
            var bad = controller.Details(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);
            
        }

        [TestMethod]
        public void TestEdit()
        {
            //Existing building(for deafult db)
            var controller = new BuildingsController();
            var good = controller.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", good.ViewName);

            //Non-existent building
            var bad = controller.Edit(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);
        }

        [TestMethod]
        public void TestCreate()
        {
            var b = new Building();
            var controller = new BuildingsController();

            //Valid building
            b.Name = "Test";
            b.Address = "Test";
            b.BuildingId = -40;
            var good = controller.Create(b) as RedirectToRouteResult;
            Assert.IsNotNull(good);
            //This seems like a bad way to do things, but...
            db.Buildings.Remove(db.Buildings.FirstOrDefault(i => i.Name == "Test" && i.Address == "Test"));
            db.SaveChanges();
        
            //Building with error
            controller.ModelState.AddModelError("test", "test");
            var bad = controller.Create(b) as ViewResult;
            Assert.AreEqual("Create", bad.ViewName);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Existing building(for deafult db)
            var controller = new BuildingsController();
            var good = controller.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", good.ViewName);

            //Non-existent building
            var bad = controller.Delete(-1) as HttpNotFoundResult;
            Assert.AreEqual(404, bad.StatusCode);
        }
    }

}