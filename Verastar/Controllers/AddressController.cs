using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Verastar.Models.AddressAggregate;
using Verastar.Services;

namespace Verastar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<MobilePhoneController> _logger;
        private readonly IAddressService _addressService;

        public AddressController(ILogger<MobilePhoneController> logger, IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<AddressResponse> GetAsync(string term)
        {
            var data = await _addressService.GetAddressListAsync(term);

            return data;
        }
    }
}
