using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Verastar.Models;

namespace Verastar.IntegrationTests
{
    [TestClass]
    public class MobilePhoneTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient client;
        public MobilePhoneTests()
        {
            _factory = new WebApplicationFactory<Startup>();
            client = _factory.CreateClient();
        }

        [TestMethod]
        public async Task TestMethod1Async()
        {
            var response = await client.GetAsync("/mobilephone");

            response.EnsureSuccessStatusCode();

            var mobiles = JsonConvert.DeserializeObject<MobilePhone[]>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(mobiles.Length, 3);
        }
    }
}
