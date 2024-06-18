using Microsoft.AspNetCore.Mvc;
using ProductsMiddleware.Interfaces;
using ProductsMiddleware.Models;
using ProductsMiddleware.Services;

namespace ProductsMiddleware.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductItem>))]
        public async Task<IActionResult> GetProducts([FromQuery] string? search = null)
        {
            var products = await _productService.GetProductsAsync();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.title.ToLower().Contains(search.ToLower()));
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }

}
