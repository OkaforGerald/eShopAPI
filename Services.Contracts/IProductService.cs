using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<OrderProducsDto> products, Metadata metadata)> GetProducts(Guid StoreId, string username, ProductParameters parameters, bool trackChanges);

        Task<OrderProducsDto> GetProductById(Guid StoreId, Guid ProductId, bool trackChanges);

        Task<OrderProducsDto> CreateProduct(Guid StoreID, string username, string imageUrl, ProductModifyingDto productDto);

        Task DeleteProducts(Guid StoreId, Guid ProductId, string username, bool trackChanges);

        Task UpdateProduct(Guid StoreId, Guid ProductId, string username, string imageUrl, ProductModifyingDto product);

        Task<(string text, string recipient)> GenerateWhatsappText(Guid StoreId, Guid ProductId);

        Task<(Product products, string recipient)> GenerateEmailText(Guid StoreId, Guid ProductId);
    }
}
