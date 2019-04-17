using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseSite.Models;
using DatabaseSite.Controllers;
using System.Web.Mvc;
using Moq;

namespace DatabaseSiteTests
{
    [TestClass]
    public class DepartmentsControllerTest
    {
        [TestMethod]
        public void TestIndexView()
        {
            var con = new Mock<DepartmentsController>();
            var result = (HttpNotFoundResult)con.Details(-1);
            var Notfound = new HttpNotFoundResult("Not a vaild Id");
            Assert.AreEqual(Notfound.StatusCode, result.StatusCode);


        }
    }
}
