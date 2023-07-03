using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Data_Transfer;

namespace Services.Contracts
{
    public interface IStoreService
    {
        Task<IEnumerable<StoresDto>> GetStores(bool trackChanges);

        Task<StoresDto> GetStoreById(Guid id, bool trackChanges);

        Task<StoresDto> CreateStore(CreateStoreDto store);

        Task DeleteStore(Guid Id);

        Task UpdateStore(Guid Id, StoreUpdateDto updateModel, bool trackChanges);
    }
}
