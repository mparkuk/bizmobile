using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Verastar.Core.IRepositories;
using Verastar.Models;

namespace Verastar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderController(ILogger<OrderController> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Order order)
        {
            await _orderRepository.Add(order);
            await _orderRepository.Save();
            return Ok(order);
        }
    }
}
