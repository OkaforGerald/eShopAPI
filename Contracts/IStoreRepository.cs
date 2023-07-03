using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetAllStores(bool trackChanges);

        Task<Store> GetStoreById(Guid Id, bool trackChanges);

        void CreateStore(Store store);

        void DeleteStore(Store store);
    }
}
