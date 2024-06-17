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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
    }

}
