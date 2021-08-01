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
using Verastar.Models.AddressAggregate;
using Verastar.Services;

namespace Verastar.UnitTests.Controllers
{
    [TestClass]
    public class AddressControllerTests
    {
        public AddressControllerTests()
        {
        }

        [TestMethod]
        public async Task CheckMobileDataIsReturned()
        {
            // Arrange
            var addressSuggestions = new List<AddressSuggestion>();
            addressSuggestions.Add(new AddressSuggestion() { address = "111 Fairywell Road, Timperley, Altrincham, Cheshire" });
            var items = new AddressResponse()
            {
                suggestions = addressSuggestions
            };
            var term = "111 Fairywell";

            var mocklogger = new Mock<ILogger<AddressController>>();
            var mock = new Mock<IAddressService>();
            mock.Setup(p => p.GetAddressListAsync(term)).Returns(Task.FromResult(items));
            var controller = new AddressController(mocklogger.Object, mock.Object);

            // Act
            var result = await controller.GetByTermAsync(term);

            //Assert
            Assert.AreEqual(items, result);
        }
    }
}
