using System;
using System.Text.Json;
using Entities.Models;
using eShop.Client.Client.Features;
using Microsoft.AspNetCore.WebUtilities;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.HttpRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public CategoryRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var response = await _client.GetAsync("categories");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var categories = JsonSerializer.Deserialize<List<CategoryDto>>(content, _options);
            return categories;
        }

        public async Task<PagingResponse<ProductsDto>> GetProductsByCategory(Guid Id, ProductParameters productParameters)
        {
			var queryStringParam = new Dictionary<string, string>
			{
				["pageNumber"] = productParameters.PageNumber.ToString(),
				["searchTerm"] = productParameters.searchTerm == null ? "" : productParameters.searchTerm,
				["orderBy"] = productParameters.orderBy == null ? "" : productParameters.orderBy
			};
			var response = await _client.GetAsync(QueryHelpers.AddQueryString($"categories/{Id}/products", queryStringParam));
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
    }
}
