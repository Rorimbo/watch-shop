using Core.DB;
using Core.Interfaces;
using Core.Models;
using Core.Models.DTO;
using Core.Models.Entities;
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

        public async Task AddCartItemAsync(CartItem cartItem)
        {
            var cart = new Cart() { ProductId = cartItem.ProductId, Quantity = cartItem.Quantity, UserId = cartItem.UserId };

            var item = await _ordersRepository.FindCartItemAsync(cart);

            if (item == null)
            {
                await _ordersRepository.AddCartAsync(cart);
            }
            else
            {
                item.Quantity += cartItem.Quantity;
                await _ordersRepository.UpdateCartAsync(item);
            }
        }

        public async Task<List<CartItem>> GetCartAsync(int userId)
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
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    OrderId = orderId
                };

                await _ordersRepository.AddOrderItemsAsync(orderItem);
                //TODO очищать корзину и обновлять продукты только в случае успешного добавления 
                await _ordersRepository.DeleteCartAsync(cartItem.Id.Value);


                var product = await _productRepository.GetInfoProductAsync(cartItem.ProductId);
                product.Quantity -= cartItem.Quantity;

                await _productRepository.UpdateProductAsync(product);
            }

            return orderId;
        }
    }
}
