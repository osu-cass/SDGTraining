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
using Moq;

namespace DatabaseSite.TestControllers
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new LoginController();
            var res = controller.Index() as ViewResult;
            Assert.AreEqual("Index", res.ViewName);
        }
    }
}
