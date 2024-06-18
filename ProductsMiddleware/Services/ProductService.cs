using ProductsMiddleware.Clients;
using ProductsMiddleware.Interfaces;
using ProductsMiddleware.Models;

namespace ProductsMiddleware.Services
{
    public class ProductService : IProductService
    {
        private readonly ApiClient _apiClient;

        public ProductService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _apiClient.GetAsync<Product>($"products/{id}");
        }

        public async Task<IEnumerable<ProductItem>> GetProductsAsync()
        {
            var response = await _apiClient.GetAsync<ProductResponse>("products?limit=0&select=thumbnail,title,price,description");
            return response.products;
        }
    }
}
