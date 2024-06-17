using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsMiddleware.Clients
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(responseData);
        }
    }
}
