using Core.Models;

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
        public Task AddCartAsync(Cart cart);

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
        public Task<List<CartForView>> GetCartAsync(int userId);
    }
}
