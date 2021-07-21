using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verastar.Services;

namespace Verastar.UnitTests.Services
{
    [TestClass]
    public class MobileService_IsPrimeShould
    {
        private readonly MobileService _mobileService;

        public MobileService_IsPrimeShould()
        {
            _mobileService = new MobileService();
        }

        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var result = _mobileService.IsPrime(1);

            Assert.IsFalse(result, $"1 should not be prime");
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _mobileService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
    }
}
