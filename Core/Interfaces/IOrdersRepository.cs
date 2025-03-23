using Core.Models;
using Core.Models.DTO;
using Core.Models.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Репозиторий заказов.
    /// </summary>
    public interface IOrdersRepository
    {
        /// <summary>
        /// Поиск элемента корзины в базе.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Task<Cart?> FindCartItemAsync(Cart cart);

        /// <summary>
        /// Добавление товара в корзину.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Task AddCartAsync(Cart  cart);

        /// <summary>
        /// Обновление товара в корзине.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Task UpdateCartAsync(Cart cart);

        /// <summary>
        /// Получение товаров в корзине для конкретного пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<CartItem>> GetCartAsync(int userId);

        /// <summary>
        /// Создание заказа.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>order id</returns>
        public Task<int> CreateOrderAsync(Order order);

        /// <summary>
        /// Добавление товара в список товаров в заказе.
        /// </summary>
        /// <param name="orderItems">Товар для добавления в список товаров в заказе</param>
        /// <returns></returns>
        public Task AddOrderItemsAsync(OrderItems orderItems);

        /// <summary>
        /// Удаление товаров из корзины.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteCartAsync(int id);
    }
}
