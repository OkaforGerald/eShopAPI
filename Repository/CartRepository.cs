using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SharedAPI.Data_Transfer;

namespace Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CreateCart(Cart cart)
        {
            Create(cart);
        }

        public void DeleteCart(Cart cart)
        {
            Delete(cart);
        }

        public async Task<Cart> GetCartForUser(string userId, bool trackChanges)
        {
            return await FindByCondition(x => x.userId.Equals(userId), trackChanges)
                .Include(x => x.CartItems)
                .FirstOrDefaultAsync();
        }

        public async Task<List<CartItemDto>> GetProductsInCart(string userId, bool trackChanges)
        {
            return await FindByCondition(x => x.userId.Equals(userId), trackChanges)
                .SelectMany(c => c.CartItems)
                .Select(ci => new CartItemDto
                {
                    Product = new OrderProducsDto
                    {
                        Id = ci.Product.Id,
                        Name = ci.Product.Name,
                        Description = ci.Product.Description,
                        ImageUrl = ci.Product.ImageUrl,
                        Brand = ci.Product.Brand,
                        Price = ci.Product.Price,
                        Quantity = ci.Product.Quantity,
                        Store = ci.Product.Store.Name,
                        StoreId = ci.Product.StoreId
                    },
                    QuantityInCart = ci.QuantityInCart,
                })
                .ToListAsync();
        }
    }
}
