using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Services.Contracts;
using Shared.Data_Transfer;

namespace Services
{
    public class StoreService : IStoreService
    {
        private readonly IMapper mapper;
        private readonly IRepositoryManager manager;

        public StoreService(IMapper mapper, IRepositoryManager manager)
        {
            this.mapper = mapper;
            this.manager = manager;
        }

        public async Task<StoresDto> CreateStore(CreateStoreDto storeDto)
        {
            var store = mapper.Map<Store>(storeDto);

            manager.stores.CreateStore(store);
            await manager.Save();

            var response = mapper.Map<StoresDto>(store);
            return response;
        }

        public async Task DeleteStore(Guid Id)
        {
            var store = await manager.stores.GetStoreById(Id, false);

            if(store is null)
            {
                throw new StoreNotFoundException(Id);
            }

            manager.stores.DeleteStore(store);
            await manager.Save();

        }

        public async Task<StoresDto> GetStoreById(Guid id, bool trackChanges)
        {
            var result = await manager.stores.GetStoreById(id, trackChanges);

            if(result is null)
            {
                throw new StoreNotFoundException(id);
            }

            var response = mapper.Map<StoresDto>(result);
            return response;
        }

        public async Task<IEnumerable<StoresDto>> GetStores(bool trackChanges)
        {
            var results = await manager.stores.GetAllStores(trackChanges);

            var response = mapper.Map<IEnumerable<StoresDto>>(results);

            return response;

        }

        public async Task UpdateStore(Guid Id, StoreUpdateDto updateModel, bool trackChanges)
        {
            var store = await manager.stores.GetStoreById(Id, trackChanges);

            store.UpdatedAt = DateTime.Now;

            if (store is null)
            {
                throw new StoreNotFoundException(Id);
            }

            mapper.Map(updateModel, store);

            await manager.Save();
        }
    }
}
