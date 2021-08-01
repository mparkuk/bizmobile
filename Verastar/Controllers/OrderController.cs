using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Verastar.Models;
using Verastar.Services;

namespace Verastar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<MobilePhoneController> _logger;
        private readonly IMobileService _mobileService;
        private readonly IMobileDataApiService _mobileDataApiService;

        public OrderController(ILogger<MobilePhoneController> logger, IMobileService mobileService, IMobileDataApiService mobileDataApiService)
        {
            _logger = logger;
            _mobileService = mobileService;
            _mobileDataApiService = mobileDataApiService;
        }

        [HttpPost]
        public ActionResult PostAsync(Order order)
        {
            return Ok();
        }
    }
}
