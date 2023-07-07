using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductsDto> products, Metadata metadata)> GetProducts(Guid StoreId, ProductParameters parameters, bool trackChanges);

        Task<ProductsDto> GetProductById(Guid StoreId, Guid ProductId, bool trackChanges);
    }
}
