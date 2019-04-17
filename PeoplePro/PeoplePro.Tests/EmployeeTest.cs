using System;
using Xunit;
using PeoplePro;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PeoplePro.Controllers;
using PeoplePro.Models;
using Microsoft.EntityFrameworkCore;

namespace PeoplePro.Tests
{
    public class EmployeeTest
    {
        #region snippet_Index_ReturnsAViewResult_WithAListOfEmployees
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfEmployees()
        {
            // Arrange
            var mockRepo = new Mock<PeopleProContext>();
            mockRepo.Setup(repo => repo.Employee.Include(d => d.Department).Include(d => d.Building).ToList()).Returns(GetTestSessions());
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Employee>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        #endregion

        #region snippet_ModelState_ValidOrInvalid
        [Fact]
        public async Task IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<PeopleProContext>();
            mockRepo.Setup(repo => repo.Employee.Include(d => d.Department).Include(d => d.Building).ToList()).Returns(GetTestSessions());
            var controller = new EmployeeController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new EmployeeController.NewSessionModel();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task IndexPost_ReturnsARedirectAndAddsSession_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<PeopleProContext>();
            mockRepo.Setup(repo => repo.Add(It.IsAny<Employee>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new EmployeeController(mockRepo.Object);
            var newSession = new EmployeeController.NewSessionModel()
            {
                SessionName = "Test Name"
            };

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }
        #endregion

        #region snippet_GetTestSessions
        private List<Employee> GetTestSessions()
        {
            var sessions = new List<Employee>();
            sessions.Add(new Employee()
            {
                ID = 0,
                FirstName = "Mario",
                BuildingID = 1,
                DepartmentID = 1
            });
            sessions.Add(new Employee()
            {
                ID = 1,
                FirstName = "Link",
                BuildingID = 2,
                DepartmentID = 2
            });
            return sessions;
        }
        #endregion
    }
}
