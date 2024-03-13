using Blazored.LocalStorage;
using eShop.Client.Client.Features;
using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.WebUtilities;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eShop.Client.Client.HttpRepository
{
    public class ProductHttpRepository : IProductHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly ILocalStorageService _localStorage;

        public ProductHttpRepository(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _localStorage = localStorage;
        }

        public async Task<PagingResponse<OrderProducsDto>> GetProducts(Guid StoreID, ProductParameters productParameters)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = productParameters.PageNumber.ToString(),
                ["searchTerm"] = productParameters.searchTerm == null ? "" : productParameters.searchTerm,
                ["orderBy"] = productParameters.orderBy == null ? "" : productParameters.orderBy
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString($"stores/{StoreID}/products", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<OrderProducsDto>
            {
                Items = JsonSerializer.Deserialize<List<OrderProducsDto>>(content, _options)!,
                MetaData = JsonSerializer.Deserialize<Metadata>(response.Headers.GetValues("X-Pagination").First(), _options)!
            };

            return pagingResponse;
        }

        public async Task CreateProduct(ProductModifyingDto product, string Id)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var content = JsonSerializer.Serialize(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync($"stores/{Id}/products", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task<string> UploadProductImage(MultipartFormDataContent content)
        {
            var postResult = await _client.PostAsync("upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = postContent;
                return imgUrl;
            }
        }

        public async Task<OrderProducsDto> GetProduct(Guid StoreID, string id)
        {
            var url = Path.Combine($"stores/{StoreID}/products", id);

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var product = JsonSerializer.Deserialize<OrderProducsDto>(content, _options);
            return product;
        }

        public async Task UpdateProduct(ProductModifyingDto product)
        {
            var content = JsonSerializer.Serialize(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = Path.Combine("products", product.Brand.ToString());

            var postResult = await _client.PutAsync(url, bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            var url = Path.Combine("products", id.ToString());

            var deleteResult = await _client.DeleteAsync(url);
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();

            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }
    }
}