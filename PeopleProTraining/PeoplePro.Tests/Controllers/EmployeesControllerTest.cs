//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PeoplePro.Dal;
//using PeoplePro.Dal.Interfaces;
//using PeoplePro;
//using PeoplePro.Controllers;

//namespace PeoplePro.Tests.Controllers
//{
//    [TestClass]
//    public class EmployeesControllerTest
//    {
//        [TestMethod]
//        public async Task Index()
//        {
//            // arrange
//            var controller = new EmployeesController();

//            // act
//            ViewResult result = await controller.Index() as ViewResult;

//            // assert
//            Assert.IsNotNull(result);
//        }
//    }
//}