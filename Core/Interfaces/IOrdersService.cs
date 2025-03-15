using Core.Models;

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
        /// <param name="cart"></param>
        /// <returns></returns>
        public Task AddCartAsync(Cart cart);

        /// <summary>
        /// Получение товаров в корзине для конкретного пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<CartForView>> GetCartAsync(int userId);

        /// <summary>
        /// Оформление заказа.
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        public Task<int> CreateOrderAsync(OrderDetails orderDetails);
    }
}
