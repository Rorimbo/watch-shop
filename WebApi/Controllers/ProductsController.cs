using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public ProductWithBrand GetAllProducts()
        {
            var product = new ProductWithBrand();
            return product;
        }

        [HttpGet]
        [Route("info/{id}")]
        public ProductWithBrand GetInfoProduct(int id)
        {
            var product = new ProductWithBrand();
            return product;
        }
    }
}
