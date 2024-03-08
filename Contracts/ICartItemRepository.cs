using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ICartItemRepository
    {
        void AddToCart(CartItem cartItem);

        void DeleteFromCart(CartItem cartItem);
    }
}
