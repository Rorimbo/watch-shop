using Core.DB;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        ApplicationContext _context;
        DbSet<Product> _dbSet;

        public ProductsRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }
        public async Task<List<ProductWithBrand>> GetAllProductsAsync()
        {
            var products = await _context.Products.Join(_context.Brands, p => p.BrandId, b => b.Id, (p, b) => new ProductWithBrand()
            {
                Id = p.Id,
                BrandId = p.BrandId,
                Title = p.Title,
                Model = p.Model,
                Price = p.Price,
                ImageUrls = p.ImageUrls,
                BrandName = b.Name,
                BrandCountry = b.Country,
            }).ToListAsync();
            return products;
        }

        public async Task<ProductWithBrand> GetInfoProductAsync(int id)
        {
            var product = await _context.Products.Join(_context.Brands, p => p.BrandId, b => b.Id, (p, b) => new ProductWithBrand()
            {
                Id = p.Id,
                BrandId = p.BrandId,
                Title = p.Title,
                Model = p.Model,
                Price = p.Price,
                ImageUrls = p.ImageUrls,
                BrandName = b.Name,
                BrandCountry = b.Country,
            })
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();
            return product;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<int?> FindBrandByName(string name)
        {
            var brand = await _context.Brands
                .Where(brand => brand.Name == name)
                .SingleOrDefaultAsync();
            if (brand != null)
            {
                return brand.Id;
            }
            return null;
        }

        public async Task<int> CreateNewBrand(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return brand.Id;
        }

        public async Task<List<ProductWithBrand>> SearchByBrand(string name)
        {
            var brandName = await _context.Products.Join(_context.Brands, p => p.BrandId, b => b.Id, (p, b) => new ProductWithBrand()
            {
                Id = p.Id,
                BrandId = p.BrandId,
                Model = p.Model,
                BrandName = b.Name,
                BrandCountry = b.Country,
            })
                .Where(b => b.BrandName.ToLower().Contains(name.ToLower()))
                .ToListAsync();
            return brandName;
        }
    }
}
