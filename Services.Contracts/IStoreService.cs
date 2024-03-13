using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace Services.Contracts
{
    public interface IStoreService
    {
        Task<(List<StoresDto> stores, Metadata metadata)> GetStores(StoreParameters parameters, string username, bool trackChanges);

        Task<StoresDto> GetStoreById(Guid id, string requester,  bool trackChanges);

        Task<StoresDto> CreateStore(string username, CreateStoreDto store);

        Task DeleteStore(string username, Guid Id);

        Task UpdateStore(Guid Id, string username, StoreUpdateDto updateModel, bool trackChanges);
    }
}
