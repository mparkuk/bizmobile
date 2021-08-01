﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Verastar.Models;
using Verastar.Services;

namespace Verastar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MobilePhoneController : ControllerBase
    {
        private readonly ILogger<MobilePhoneController> _logger;
        private readonly IMobileService _mobileService;
        private readonly IMobileDataApiService _mobileDataApiService;

        public MobilePhoneController(ILogger<MobilePhoneController> logger, IMobileService mobileService, IMobileDataApiService mobileDataApiService)
        {
            _logger = logger;
            _mobileService = mobileService;
            _mobileDataApiService = mobileDataApiService;
        }

        [HttpGet]
        public async Task<IEnumerable<MobilePhone>> GetAsync()
        {
            //var data = await _mobileDataApiService.GetMobileInfo();

            return await _mobileService.GetMobileDataAsync();
        }
    }
}