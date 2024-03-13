using eShop.Client.Client.Features;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.HttpRepository
{
    public interface IStoreService
    {
        Task<PagingResponse<StoresDto>> GetStores(StoreParameters storeParameters);

        Task CreateStore(CreateStoreDto product);
    }
}
