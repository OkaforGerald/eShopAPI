using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using SharedAPI.Request_Features;

namespace Contracts
{
    public interface IStoreRepository
    {
        Task<PagedList<Store>> GetAllStores(StoreParameters parameters, bool trackChanges);

        Task<Store> GetStoreById(Guid Id, bool trackChanges);

        Task<Store> GetStoreByOwnerId(string Id, bool trackChanges);

        void CreateStore(Store store);

        void DeleteStore(Store store);
    }
}
