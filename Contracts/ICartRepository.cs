using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using SharedAPI.Data_Transfer;

namespace Contracts
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);

        void DeleteCart(Cart cart);

        Task<Cart> GetCartForUser(string userId, bool trackChanges);

        Task<List<CartItemDto>> GetProductsInCart(string userId, bool trackChanges);
    }
}
