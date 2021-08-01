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
    public class MobilePhoneControllerTests
    {
        public MobilePhoneControllerTests()
        {
        }

        [TestMethod]
        public async Task CheckMobileDataIsReturned()
        {
            // Arrange
            var items = new List<MobilePhone>()
            {
                new MobilePhone{Name="S10", Manufacture="Samsung", LastUpdated=DateTime.Now, ImagePath="/images/samsung-galaxy-s10.jpg" }
            };
            var mocklogger = new Mock<ILogger<MobilePhoneController>>();
            var mock = new Mock<IMobilePhoneRepository>();
            mock.Setup(p => p.All()).Returns(Task.FromResult(items.AsEnumerable()));
            var controller = new MobilePhoneController(mocklogger.Object, mock.Object);

            // Act
            var result = await controller.GetAsync();

            //Assert
            Assert.AreEqual(items, result);
        }
    }
}
