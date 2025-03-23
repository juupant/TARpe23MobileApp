using E_Commerce.Shared.Dtos;
using Models;

namespace Services
{
    public class ProductsService : BaseApiService
    {
        public ProductsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        public async Task<IEnumerable<ProductDto>> GetPopularProductsAsync()
        {
            var response = await HttpClient.GetAsync("/masters/popular-products");
            return await HandleApiResponseAsync(response, Enumerable.Empty<ProductDto>());
        }
    }
}