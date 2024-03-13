using System.Net.Http.Headers;
using System.Text.Json;
using Blazored.LocalStorage;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.HttpRepository
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public event Action<int> OnShoppingCartChanged;
        private readonly ILocalStorageService _localStorage;

        public ShoppingCartService(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _localStorage = localStorage;
        }

        public async Task<List<CartItemDto>> GetCart()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            var response = await _client.GetAsync("cart");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<CartItemDto>().ToList();
            }
            var cartItems = JsonSerializer.Deserialize<List<CartItemDto>>(content, _options);
            return cartItems;
        }

        public async Task<List<OrderProductDto>> GetOrders()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await _client.GetAsync("orders");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<OrderProductDto>().ToList();
            }
            var orders = JsonSerializer.Deserialize<List<OrderProductDto>>(content, _options);
            return orders;
        }

        public async Task AddtoCart(Guid StoreId, string productId)
        {
            var response = await _client.PostAsync($"stores/{StoreId}/products/{productId}/cart", null);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public void RaiseEventOnShoppingCartChanged(int totalQty)
        {
            if (OnShoppingCartChanged != null)
            {
                OnShoppingCartChanged.Invoke(totalQty);
            }
        }

        public async Task<OrderProducsDto> DeleteItem(Guid id)
        {
            return new OrderProducsDto();
        }
    }
}
