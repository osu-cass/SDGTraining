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
    public class BuildingsControllerTests
    { 
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new BuildingsController();
            var result = controller.Index() as ViewResult;
            var buildings = (ICollection<Building>) result.ViewData.Model;
            Assert.AreEqual("Bexell Hall", buildings.ToArray()[1].Name);
        }

        [TestMethod()]
        public void DetailsTestName()
        {
            var controller = new BuildingsController();
            var result = controller.Details(4) as ViewResult;
            var building = (Building) result.ViewData.Model;
            Assert.AreEqual("Dearborn Hall", building.Name);
        }
        [TestMethod()]
        public void DetailsTestAddress()
        {
            var controller = new BuildingsController();
            var result = controller.Details(4) as ViewResult;
            var building = (Building)result.ViewData.Model;
            Assert.AreEqual("1891 SW Campus Wy.", building.Address);
        }

        [TestMethod()]
        public void DetailsTestDepartment()
        {
            var controller = new BuildingsController();
            var result = controller.Details(4) as ViewResult;
            var building = (Building)result.ViewData.Model;
            Assert.AreEqual("College of Engineering", building.Department.Name);
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
            var newBuilding = new Building();
            newBuilding.Name = "TestBuildingName";
            newBuilding.Address = "TestBuildingAddress";
            newBuilding.DepartmentId = 1;

            var controller = new BuildingsController();
            controller.Create(newBuilding);
            var result = controller.Index() as ViewResult;
            var buildings = (ICollection<Building>)result.ViewData.Model;
            Assert.AreEqual("TestBuildingName", buildings.Last().Name); 
        }
        public void EditTest()
        {
            var controller = new BuildingsController();
            var result = controller.Index() as ViewResult;
            var buildings = (ICollection<Building>)result.ViewData.Model;
            var editBuilding = buildings.Last();
            editBuilding.Name = "NewBuildingName";
            editBuilding.Address = "NewBuildingAddress";
            controller.Edit(editBuilding);

            var result2 = controller.Index() as ViewResult;
            var buildings2 = (ICollection<Building>)result2.ViewData.Model;
            Assert.AreEqual("NewBuildingName", buildings2.Last().Name);
        }
        public void DeleteTest()
        {
            var controller = new BuildingsController();
            var result = controller.Index() as ViewResult;
            var buildings = (ICollection<Building>)result.ViewData.Model;
            var Id = buildings.Last().BuildingId;
            controller.DeleteConfirmed(Id);

            var result2 = controller.Index() as ViewResult;
            var buildings2 = (ICollection<Building>)result.ViewData.Model;
            Assert.AreNotEqual(Id, buildings2.Last().BuildingId);
        }
    }
}