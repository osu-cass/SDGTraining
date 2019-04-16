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
            mockRepo.Setup(repo => repo.Employee).ReturnsAsync(GetTestSessions());
            var controller = new EmployeeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
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
                ID = 0,
                FirstName = "Link",
                BuildingID = 2,
                DepartmentID = 2
            });
            return sessions;
        }
        #endregion
    }
}
