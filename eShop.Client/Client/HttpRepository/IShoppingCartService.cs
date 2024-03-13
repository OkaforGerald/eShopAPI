using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.HttpRepository
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDto>> GetCart();

        Task<OrderProducsDto> DeleteItem(Guid id);

        Task AddtoCart(Guid StoreId, string productId);

        Task<List<OrderProductDto>> GetOrders();

        event Action<int> OnShoppingCartChanged;
        void RaiseEventOnShoppingCartChanged(int totalQty);
    }
}
