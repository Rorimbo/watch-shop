using Core.BusinessLogic;
using Core.DB;
using Core.Interfaces;
using Core.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        ApplicationContext _context;
        private readonly ILogger<ProductsController> _logger;
        private IProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
            _productsService = new ProductsService(_context);
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<ProductWithBrand>> GetAllProductsAsync()
        {
            var product = await _productsService.GetAllProductsAsync();
            return product;
        }

        [HttpGet]
        [Route("info/{id}")]
        public async Task<ProductWithBrand> GetInfoProductAsync(int id)
        {
            var product = await _productsService.GetInfoProductAsync(id);
            return product;
        }

        [HttpPost]
        public async Task CreateProductAsync(ProductWithBrand product)
        {
            await _productsService.CreateProductAsync(product);
        }

        [HttpGet]
        [Route("search/{name}")]
        public async Task<List<ProductWithBrand>> SearchByBrand(string name)
        {
            var brandName = await _productsService.SearchByBrand(name);
            return brandName;
        }
    }
}
