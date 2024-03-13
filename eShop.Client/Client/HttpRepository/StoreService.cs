using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
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
        private readonly ILocalStorageService _localStorage;

        public StoreService(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _localStorage = localStorage;
        }

        public async Task<PagingResponse<StoresDto>> GetStores(StoreParameters storeParameters)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
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

        public async Task CreateStore(CreateStoreDto product)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var content = JsonSerializer.Serialize(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("stores", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }
    }
}
