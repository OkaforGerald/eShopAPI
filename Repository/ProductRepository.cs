using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public async Task<Product> GetProductById(Guid StoreId, Guid ProductId, bool trackChanges)
        {
            var product = await FindByCondition(x => x.StoreId == StoreId && x.Id == ProductId, trackChanges)
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<PagedList<Product>> GetProducts(Guid StoreId, ProductParameters parameters, bool trackChanges)
        {
            var products = await FindByCondition(x => x.StoreId == StoreId, trackChanges)
                .Where(x => x.Brand.Contains(parameters.searchTerm) || x.Name.Contains(parameters.searchTerm))
                .Where(x => x.Price >= parameters.minPrice && x.Price <= parameters.maxPrice)
                .Sort(parameters.orderBy)
                .ToListAsync();

            return PagedList<Product>.ToPagedList(products, parameters.PageNumber, parameters.PageSize);

        }

        public async Task<PagedList<Product>> GetProductsByCategory(Guid CategoryId, ProductParameters parameters, bool trackChanges)
        {
            var products = await FindByCondition(x => x.CategoryId == CategoryId, trackChanges)
                .Where(x => x.Brand.Contains(parameters.searchTerm) || x.Name.Contains(parameters.searchTerm))
                .Where(x => x.Price >= parameters.minPrice && x.Price <= parameters.maxPrice)
                .Sort(parameters.orderBy)
                .ToListAsync();

            return PagedList<Product>.ToPagedList(products, parameters.PageNumber, parameters._pageSize);
        }
    }
}
