using Core.Models;
using Core.Models.DTO;

namespace Core.Interfaces
{
    /// <summary>
    /// Сервис заказов.
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Добавление товара в корзину.
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        public Task AddCartItemAsync(CartItem cartItem);

        /// <summary>
        /// Получение товаров в корзине для конкретного пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<CartItem>> GetCartAsync(int userId);

        /// <summary>
        /// Оформление заказа.
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        public Task<int> CreateOrderAsync(OrderDetails orderDetails);
    }
}
