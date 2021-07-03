using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verastar.Data;

namespace Verastar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MobilePhoneController : ControllerBase
    {
        private readonly TelecomContext _context;

        private readonly ILogger<MobilePhoneController> _logger;

        public MobilePhoneController(ILogger<MobilePhoneController> logger, TelecomContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Models.MobilePhone> Get()
        {
            return _context.MobilePhones.ToList();
        }
    }
}
