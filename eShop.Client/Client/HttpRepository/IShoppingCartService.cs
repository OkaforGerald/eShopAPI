using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.HttpRepository
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDto>> GetCart();

        Task<ProductsDto> DeleteItem(Guid id);

        Task AddtoCart(Guid StoreId, string productId);

        event Action<int> OnShoppingCartChanged;
        void RaiseEventOnShoppingCartChanged(int totalQty);
    }
}
