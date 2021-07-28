using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Verastar.Data;
using Verastar.Services;

namespace Verastar.UnitTests.Services
{
    [TestClass]
    public class MobileService_IsPrimeShould
    {
        private readonly MobileService _mobileService;
        protected DbContextOptions<TelecomContext> ContextOptions { get; }
        private readonly TelecomContext context;

        public MobileService_IsPrimeShould()
        {
            ContextOptions = new DbContextOptionsBuilder<TelecomContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;
            context = new TelecomContext(ContextOptions);
            _mobileService = new MobileService(context);
            Seed();
        }

        private void Seed()
        {
            using (var context = new TelecomContext(ContextOptions))
            {

                context.Database.EnsureDeleted();

                DbInitializer.Initialize(context);

            }
        }

        [TestMethod]
        public async Task CheckMobileDataIsLoaded()
        {
            var result = await _mobileService.GetMobileDataAsync();

            Assert.IsTrue(result.Count > 0);
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
