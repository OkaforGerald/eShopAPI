using System.Text.Json;
using eShop.Client.Client.Features;
using Microsoft.AspNetCore.WebUtilities;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.HttpRepository
{
    public class StoreService : IStoreService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public StoreService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<PagingResponse<StoresDto>> GetStores(StoreParameters storeParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = storeParameters.PageNumber.ToString(),
                ["searchTerm"] = storeParameters.searchTerm == null ? "" : storeParameters.searchTerm,
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString($"stores", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<StoresDto>
            {
                Items = JsonSerializer.Deserialize<List<StoresDto>>(content, _options)!,
                MetaData = JsonSerializer.Deserialize<Metadata>(response.Headers.GetValues("X-Pagination").First(), _options)!
            };

            return pagingResponse;
        }
    }
}
