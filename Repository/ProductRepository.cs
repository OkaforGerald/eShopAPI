using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task<PagedList<Product>> GetProducts(Guid StoreId, ProductParameters parameters, bool trackChanges)
        {
            var products = await FindByCondition(x => x.StoreId == StoreId, trackChanges)
                .Where(x => x.Brand.Contains(parameters.searchTerm) || x.Name.Contains(parameters.searchTerm))
                .ToListAsync();

            return PagedList<Product>.ToPagedList(products, parameters.PageNumber, parameters.PageSize);

        }
    }
}
