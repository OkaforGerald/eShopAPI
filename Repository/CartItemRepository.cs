using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        public CartItemRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void AddToCart(CartItem cartItem)
        {
            Create(cartItem);
        }

        public void DeleteFromCart(CartItem cartItem)
        {
            Delete(cartItem);
        }
    }
}
