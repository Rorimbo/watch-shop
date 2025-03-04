using Core.Models;

namespace Core.Interfaces
{
    /// <summary>
    /// Сервис товаров.
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Получение списка всех товаров.
        /// </summary>
        /// <returns></returns>
        public Task<List<ProductWithBrand>> GetAllProductsAsync();

        /// <summary>
        /// Получение информации о товаре.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ProductWithBrand> GetInfoProductAsync(int id);

        /// <summary>
        /// Добавление нового товара в базу.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Task CreateProductAsync(ProductWithBrand product);

    }
}
