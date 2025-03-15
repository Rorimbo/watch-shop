using Core.DB;
using Core.Interfaces;
using Core.Models;
using Core.Repositories;

namespace Core.BusinessLogic
{
    public class ProductsService : IProductsService
    {
        ApplicationContext _context;

        private IProductsRepository _productsRepository;
        public ProductsService(ApplicationContext context)
        {
            _context = context;
            _productsRepository = new ProductsRepository(_context);
        }

        public async Task<List<ProductWithBrand>> GetAllProductsAsync()
        {
            var products = await _productsRepository.GetAllProductsAsync();
            return products;
        }

        public async Task<ProductWithBrand> GetInfoProductAsync(int id)
        {
            var product = await _productsRepository.GetInfoProductAsync(id);
            return product;
        }

        public async Task CreateProductAsync(ProductWithBrand product)
        {
            var brandId = await _productsRepository.FindBrandByName(product.BrandName);
            if (brandId == null)
            {
                var brand = new Brand()
                {
                    Name = product.BrandName,
                    Country = product.BrandCountry
                };

                brandId = await _productsRepository.CreateNewBrand(brand);
            }

            var newProduct = new Product()
            {
                BrandId = brandId.Value,
                Title = product.Title,
                Model = product.Model,
                Price = product.Price,
                ImageUrls = product.ImageUrls,
                Quantity = product.Quantity
            };

            await _productsRepository.CreateProductAsync(newProduct);
        }

        public async Task<List<ProductWithBrand>> SearchByBrand(string name)
        {
            var brandName = await _productsRepository.SearchByBrand(name);
            return brandName;
        }
    }
}
