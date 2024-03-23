using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace Services
{
    public class StoreService : IStoreService
    {
        private readonly IMapper mapper;
        private readonly IRepositoryManager manager;
        private readonly UserManager<User> userManager;

        public StoreService(IMapper mapper, IRepositoryManager manager, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.manager = manager;
            this.userManager = userManager;
        }

        public async Task<StoresDto> CreateStore(string username, CreateStoreDto storeDto)
        {
            //Get stores that have been created by user; if null - Create new store; else - throw exception
            var user = await userManager.FindByNameAsync(username);

            var store = await manager.stores.GetStoreByOwnerId(user.Id, trackChanges: false);
            if (store is null)
            {
                var newStore = mapper.Map<Store>(storeDto);

                newStore.PhoneNumber = user.PhoneNumber;
                newStore.Email = user.Email;
                newStore.UserId = user.Id;
                newStore.CreatedAt = DateTime.UtcNow;

                manager.stores.CreateStore(newStore);
                await manager.Save();

                var response = mapper.Map<StoresDto>(newStore);
                return response;
            }

            throw new Exception("User already has a store");
        }

        public async Task DeleteStore(string username, Guid Id)
        {
            var user = await userManager.FindByNameAsync(username);

            var store = await manager.stores.GetStoreById(Id, false);

            if(store is null)
            {
                throw new StoreNotFoundException(Id);
            }

            if(store.UserId == user.Id || await userManager.IsInRoleAsync(user, "Administrator"))
            {
                manager.stores.DeleteStore(store);
                await manager.Save();
            }
            else
            {
                throw new Exception("Not authorized to delete this store");
            }

        }

        public async Task<StoresDto> GetStoreById(Guid id, string requester, bool trackChanges)
        {
            var user = await userManager.FindByNameAsync(requester);

            var result = await manager.stores.GetStoreById(id, trackChanges);

            if(result is null)
            {
                throw new StoreNotFoundException(id);
            }
            bool requestedByUser = false;
            if (result.UserId is not null)
            {
                requestedByUser = result.UserId.Equals(user.Id);
            }

            var response = mapper.Map<StoresDto>(result);
            response.requestedByOwner = requestedByUser;
            if (result.UserId is not null)
            {
                var owner = await userManager.FindByIdAsync(result.UserId);
                var name = $"{owner.FirstName} {owner.FirstName}";
                response.OwnedBy = name;
            }
            return response;
        }

        public async Task<(List<StoresDto> stores, Metadata metadata)> GetStores(StoreParameters parameters, string username, bool trackChanges)
        {
            //Get Store Owners with stores
            var user = await userManager.FindByNameAsync(username);
            var store = await manager.stores.GetStoreByOwnerId(user.Id, trackChanges);
            var results = await manager.stores.GetAllStores(parameters, trackChanges);

            var response = mapper.Map<List<StoresDto>>(results);
            response[0].storeOwner = store is not null;

            return (stores: response, results.Metadata);
        }

        public async Task UpdateStore(Guid Id, string username, StoreUpdateDto updateModel, bool trackChanges)
        {
            var user = await userManager.FindByNameAsync(username);

            var store = await manager.stores.GetStoreById(Id, trackChanges);

            store.UpdatedAt = DateTime.Now;

            if (store is null)
            {
                throw new StoreNotFoundException(Id);
            }

            if (store.UserId == user.Id || await userManager.IsInRoleAsync(user, "Administrator"))
            {
                mapper.Map(updateModel, store);
                await manager.Save();
            }
            else
            {
                throw new Exception("Not authorized to update this store");
            }
        }
    }
}
