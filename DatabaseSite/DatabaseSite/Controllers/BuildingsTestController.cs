using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseSite.Controllers;

namespace DatabaseSite.TestControllers
{
    [TestClass]
    public class BuildingsTestController : Controller
    {
        // GET: BuildingsTest
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new BuildingsController();
            var res = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", res.ViewName);
        }
    }
}