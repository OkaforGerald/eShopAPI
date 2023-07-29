using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductsDto> products, Metadata metadata)> GetProducts(Guid StoreId, ProductParameters parameters, bool trackChanges);

        Task<ProductsDto> GetProductById(Guid StoreId, Guid ProductId, bool trackChanges);

        Task<ProductsDto> CreateProduct(Guid StoreID, string imageUrl, ProductModifyingDto productDto);

        Task DeleteProducts(Guid StoreId, Guid ProductId, bool trackChanges);

        Task UpdateProduct(Guid StoreId, Guid ProductId, string imageUrl, ProductModifyingDto product);

        Task<(string text, string recipient)> GenerateWhatsappText(Guid StoreId, Guid ProductId);

        Task<(Product products, string recipient)> GenerateEmailText(Guid StoreId, Guid ProductId);
    }
}
