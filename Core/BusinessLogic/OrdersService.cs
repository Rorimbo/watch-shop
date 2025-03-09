using Core.DB;
using Core.Interfaces;
using Core.Models;
using Core.Repositories;

namespace Core.BusinessLogic
{
    public class OrdersService : IOrdersService
    {
        ApplicationContext _context;

        private IOrdersRepository _ordersRepository;
        public OrdersService(ApplicationContext context)
        {
            _context = context;
            _ordersRepository = new OrdersRepository(_context);
        }

        public async Task AddCartAsync(Cart cart)
        {
            var cartItem = await _ordersRepository.FindCartItemAsync(cart);

            if (cartItem == null)
            {
                await _ordersRepository.AddCartAsync(cart);
            }
            else
            {
                cartItem.Quantity += cart.Quantity;
                await _ordersRepository.UpdateCartAsync(cartItem);
            }
        }

        public async Task<List<CartForView>> GetCartAsync(int userId)
        {
            var cartItems = await _ordersRepository.GetCartAsync(userId);
            return cartItems;
        }
    }
}
