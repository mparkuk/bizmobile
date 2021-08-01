using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Verastar.Core.IRepositories;
using Verastar.Models;
using Verastar.Services;

namespace Verastar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MobilePhoneController : ControllerBase
    {
        private readonly ILogger<MobilePhoneController> _logger;
        private readonly IMobilePhoneRepository _mobilePhoneRepository;
        //private readonly IMobileDataApiService _mobileDataApiService;

        public MobilePhoneController(ILogger<MobilePhoneController> logger, IMobilePhoneRepository mobilePhoneRepository)
        {
            _logger = logger;
            _mobilePhoneRepository = mobilePhoneRepository;
            //_mobileDataApiService = mobileDataApiService;
        }

        [HttpGet]
        public async Task<IEnumerable<MobilePhone>> GetAsync()
        {
            //var data = await _mobileDataApiService.GetMobileInfo();

            return await _mobilePhoneRepository.All();
        }
    }
}
