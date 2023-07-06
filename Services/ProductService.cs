using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Services.Contracts;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public ProductService(IMapper mapper, IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<(IEnumerable<ProductsDto> products, Metadata metadata)> GetProducts(Guid StoreId, ProductParameters parameters, bool trackChanges)
        {
            var store = await repositoryManager.stores.GetStoreById(StoreId, trackChanges: false);

            if(store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }

            var products = await repositoryManager.products.GetProducts(StoreId, parameters, trackChanges: false);

            var result = mapper.Map<IEnumerable<ProductsDto>>(products);

            return (products: result, metadata: products.Metadata);

        }
    }
}
