using Constants;
using Models;
using System.Text.Json;

namespace Services
{
    public class OffersService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public OffersService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Offer>> GetActiveOffersAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
            var resp = await httpClient.GetAsync("/masters/offers");
            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    return JsonSerializer.Deserialize<IEnumerable<Offer>>(content, new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }
            return Enumerable.Empty<Offer>();
        }
    }
}