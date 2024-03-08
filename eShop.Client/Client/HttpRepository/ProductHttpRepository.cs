using eShop.Client.Client.Features;
using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.WebUtilities;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;
using System.Text;
using System.Text.Json;

namespace eShop.Client.Client.HttpRepository
{
    public class ProductHttpRepository : IProductHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public ProductHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<PagingResponse<ProductsDto>> GetProducts(Guid StoreID, ProductParameters productParameters)
        {
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
            var pagingResponse = new PagingResponse<ProductsDto>
            {
                Items = JsonSerializer.Deserialize<List<ProductsDto>>(content, _options)!,
                MetaData = JsonSerializer.Deserialize<Metadata>(response.Headers.GetValues("X-Pagination").First(), _options)!
            };

            return pagingResponse;
        }

        public async Task CreateProduct(ProductModifyingDto product)
        {
            var content = JsonSerializer.Serialize(product);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("products", bodyContent);
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
                var imgUrl = Path.Combine("https://localhost:5011/", postContent);
                return imgUrl;
            }
        }

        public async Task<ProductsDto> GetProduct(Guid StoreID, string id)
        {
            var url = Path.Combine($"stores/{StoreID}/products", id);

            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var product = JsonSerializer.Deserialize<ProductsDto>(content, _options);
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