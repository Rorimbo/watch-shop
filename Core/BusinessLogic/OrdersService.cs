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
        private IProductsRepository _productRepository;
        public OrdersService(ApplicationContext context)
        {
            _context = context;
            _ordersRepository = new OrdersRepository(_context);
            _productRepository = new ProductsRepository(_context);
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

        public async Task<int> CreateOrderAsync(OrderDetails orderDetails)
        {
            var newOrder = new Order()
            {
                UserId = orderDetails.UserId,
                TotalAmount = orderDetails.TotalAmount,
                ShippingAddress = orderDetails.ShippingAddress,
                PaymentMethod = orderDetails.PaymentMethod
            };

            var orderId = await _ordersRepository.CreateOrderAsync(newOrder);

            foreach (var cartItem in orderDetails.Cart)
            {
                var orderItem = new OrderItems()
                {
                    ProductId = cartItem.ProductId.Value,
                    Quantity = cartItem.Quantity,
                    OrderId = orderId
                };

                await _ordersRepository.AddOrderItemsAsync(orderItem);
                await _ordersRepository.DeleteCartAsync(cartItem.Id);

                var product = new Product()
                {
                    Id = cartItem.Id,
                    BrandId = cartItem.BrandId,
                    Title = cartItem.Title,
                    Model = cartItem.Model,
                    Price = cartItem.Price,
                    ImageUrls = cartItem.ImageUrls,
                    Quantity = cartItem.Quantity
                };

                if (cartItem.Quantity != null)
                {
                    cartItem.Quantity -= cartItem.Quantity;
                }

                await _productRepository.UpdateProductAsync(product);
            }

            return orderId;
        }
    }
}
