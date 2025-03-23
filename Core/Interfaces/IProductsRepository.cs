using Core.Models;
using Core.Models.DTO;

namespace Core.Interfaces
{
    /// <summary>
    /// Репозиторий товаров.
    /// </summary>
    public interface IProductsRepository
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
        public Task CreateProductAsync(Product product);

        /// <summary>
        /// Поиск бренда по именованию.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<int?> FindBrandByName(string name);

        /// <summary>
        /// Создание нового бренда.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Task<int> CreateNewBrand(Brand brand);

        /// <summary>
        /// Поиск товара по имени бренда.
        /// </summary>
        /// <returns></returns>
        public Task<List<ProductWithBrand>> SearchByBrand(string name);

        /// <summary>
        /// Обновление товара в базе.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Task UpdateProductAsync(Product product);

    }
}
