using ProductsMiddleware.Models;

namespace ProductsMiddleware.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItem>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}