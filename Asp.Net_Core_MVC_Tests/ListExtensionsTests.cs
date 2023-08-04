using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.Net_Core_MVC_WebApp.Extensions;
using _Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using Asp.Net_Core_MVC_WebApp.Controllers;
using Asp.Net_Core_MVC_WebApp.Models;

namespace Asp.Net_Core_MVC_Tests
{
    [TestFixture]
    public  class ListExtensionsTests
    {

        [Test]
        public void File_FiveElementsValidLeader_ReturnsCorrectLeader()
        {
            // Arrange
            List<int> csvData = new List<int> { 2, 2, 2, 2, 2 };

            // Act
            int file = csvData.File();

            // Assert
            Assert.AreEqual(2, file);
        }

        [Test]
        public void File_FiveElementsNoValidLeader_ReturnsNegativeOne()
        {
            // Arrange
            List<int> csvData = new List<int> { 1, 1, 1, 1, 50 };

            // Act
            int leader = csvData.File();

            // Assert
            Assert.AreEqual(-1, leader);
        }

        [Test]
        public void File_EmptyList_ReturnsNegativeOne()
        {
            // Arrange
            List<int> csvData = new List<int>();

            // Act
            int leader = csvData.File();

            // Assert
            Assert.AreEqual(-1, leader);
        }

        [Test]
        public void File_InvalidCsvFile_ReturnsNegativeOne()
        {
            // Arrange
            var csvService = new CsvService();
            var invalidFile = csvService.GenerateInvalidCsvFile();
            var formCollection = new FormCollection(new Dictionary<string, StringValues>(), new FormFileCollection { (IFormFile)invalidFile });

            // Create a mock HttpContext with the invalid file
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(c => c.Request.Form).Returns(formCollection);

            // Create a ControllerContext with the mock HttpContext
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContextMock.Object
            };

          
            var leaderController = new FileController()
            {
                ControllerContext = controllerContext
            };

            // Act
            var result = leaderController.Index(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(-1, (result.Model as FileModel)?.FileValue);
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
        }
    }
}
