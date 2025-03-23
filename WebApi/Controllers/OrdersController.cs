using Core.BusinessLogic;
using Core.DB;
using Core.Interfaces;
using Core.Models.DTO;
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
        public async Task AddCartItemAsync(CartItem cartItem)
        {
            await _ordersService.AddCartItemAsync(cartItem);
        }

        [HttpGet]
        [Route("cart/{userId}")]
        public async Task<List<CartItem>> GetCartAsync(int userId)
        {
            var cartItems = await _ordersService.GetCartAsync(userId);
            return cartItems;
        }

        [HttpPost]
        [Route("order")]
        public async Task<int?> CreateOrderAsync(OrderDetails orderDetails)
        {
            var id = await _ordersService.CreateOrderAsync(orderDetails);
            return id;
        }
    }
}
