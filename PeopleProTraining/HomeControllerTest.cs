using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeoplePro;
using PeoplePro.Controllers;

namespace PeoplePro.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest : Controller
    {
        [TestMethod]
        public void Index()
        {
            // arrange
            HomeController controller = new HomeController();
            // act
            ViewResult result = controller.Index() as ViewResult;
            // assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // arrange
            HomeController controller = new HomeController();
            // act
            ViewResult result = controller.About() as ViewResult;
            // assert
            Assert.AreEqual("Your application description page.", result.ViewData["Message"]);
        }

        [TestMethod]
        public void Contact()
        {
            // arrange
            HomeController controller = new HomeController();
            // act
            ViewResult result = controller.Contact() as ViewResult;
            // assert
            Assert.AreEqual("Your contact page.", result.ViewData["Message"]);
        }

        [TestMethod]
        public void Privacy()
        {
            // arrange
            HomeController controller = new HomeController();
            // act
            ViewResult result = controller.Privacy() as ViewResult;
            // assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void Error()
        //{
        //    // arrange
        //    HomeController controller = new HomeController();
        //    // act
        //    ViewResult result = controller.Error() as ViewResult;
        //    // assert
        //    Assert.IsNotNull(result);
        //}
    }
}