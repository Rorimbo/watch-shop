using Core.BusinessLogic;
using Core.DB;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        ApplicationContext _context;
        private readonly ILogger<OrdersController> _logger;
        private IOrdersService _ordersService;

        public OrdersController(ILogger<OrdersController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
            _ordersService = new OrdersService(_context);
        }

        [HttpPost]
        [Route("cart")]
        public async Task AddCartAsync(Cart cart)
        {
            await _ordersService.AddCartAsync(cart);
        }

        [HttpGet]
        [Route("cart/{userId}")]
        public async Task<List<CartForView>> GetCartAsync(int userId)
        {
            var cartItems = await _ordersService.GetCartAsync(userId);
            return cartItems;
        }
    }
}
