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
    public class HomeTestController : Controller
    {

        // GET: DepartmentsTest
        [TestMethod]
        public void TestIndex()
        {
            var controller = new HomeController();
            var res = controller.Index() as ViewResult;
            Assert.AreEqual("Index", res.ViewName);
        }

        [TestMethod]
        public void TestAbout()
        {
            var controller = new HomeController();
            var res = controller.About() as ViewResult;
            Assert.AreEqual("About", res.ViewName);
        }

        [TestMethod]
        public void TestContact()
        {
            var controller = new HomeController();
            var res = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", res.ViewName);
        }
    }
}