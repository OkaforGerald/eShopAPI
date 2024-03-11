using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SharedAPI.Data_Transfer;

namespace Services.Contracts
{
    public interface ICartService
    {
        Task AddToCart(Guid StoreId, Guid ProductId, string username);

        Task<List<CartItemDto>> GetCartProducts(string username);

        Task CheckoutCart(string username);

        Task<List<OrderProductDto>> GetUserOrdersAsync(string username);

        Task<OrderProductDto> GetUserOrderById(string username, Guid Id);
    }
}
