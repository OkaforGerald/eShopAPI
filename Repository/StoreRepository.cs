using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SharedAPI.Request_Features;

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

        public async Task<PagedList<Store>> GetAllStores(StoreParameters parameters, bool trackChanges)
        {
            var stores = await FindAll(trackChanges)
                .Where(x => x.Name.Contains(parameters.searchTerm))
                .OrderBy(s => s.CreatedAt)
                .ToListAsync();

            return PagedList<Store>.ToPagedList(stores, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Store> GetStoreById(Guid Id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id.Equals(Id), trackChanges)
                .FirstOrDefaultAsync();
        }

        public async Task<Store> GetStoreByOwnerId(string Id, bool trackChanges)
        {
            return await FindByCondition(x => x.UserId == Id, trackChanges)
                .FirstOrDefaultAsync();
        }
    }
}
