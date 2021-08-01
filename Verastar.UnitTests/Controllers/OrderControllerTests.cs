using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verastar.Controllers;
using Verastar.Core.IRepositories;
using Verastar.Data;
using Verastar.Models;

namespace Verastar.UnitTests.Controllers
{
    [TestClass]
    public class OrderControllerTests
    {
        public OrderControllerTests()
        {
        }

        [TestMethod]
        public async Task CheckPostOrder()
        {
            // Arrange
            var item = new Order()
            {
                CompanyName = "Test company",
                AgreeTerms = true,
                FirstName = "Test",
                LastName = "Person"
            };

            var mocklogger = new Mock<ILogger<OrderController>>();
            var mock = new Mock<IOrderRepository>();
            mock.Setup(p => p.Add(item)).Returns(Task.FromResult(true));
            var controller = new OrderController(mocklogger.Object, mock.Object);

            // Act
            var result = await controller.PostAsync(item);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
