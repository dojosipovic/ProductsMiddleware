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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _apiClient.GetAsync<ProductResponse>("products?limit=0");
            return response.products;
        }
    }
}
