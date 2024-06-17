using ProductsMiddleware.Models;

namespace ProductsMiddleware.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}