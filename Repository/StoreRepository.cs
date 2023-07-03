using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext Context) : base(Context) { }

        public void CreateStore(Store store)
        {
           Create(store);
        }

        public void DeleteStore(Store store)
        {
            Delete(store);
        }

        public async Task<IEnumerable<Store>> GetAllStores(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Store> GetStoreById(Guid Id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id.Equals(Id), trackChanges)
                .FirstOrDefaultAsync();
        }
    }
}
