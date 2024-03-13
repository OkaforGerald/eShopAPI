using eShop.Client.Client.Features;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<PagingResponse<OrderProducsDto>> GetProducts(Guid StoreID, ProductParameters productParameters);

        Task CreateProduct(ProductModifyingDto product, string Id);

        Task<string> UploadProductImage(MultipartFormDataContent content);

        Task<OrderProducsDto> GetProduct(Guid StoreID, string id);

        Task UpdateProduct(ProductModifyingDto product);

        Task DeleteProduct(Guid id);
    }
}