using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using SharedAPI.Data_Transfer;

namespace Services
{
    public class CartService : ICartService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public CartService(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task AddToCart(Guid StoreId, Guid ProductId, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            var store = await repositoryManager.stores.GetStoreById(StoreId, false);

            if (store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }
            var product = await repositoryManager.products.GetProductById(StoreId, ProductId, false);

            if (product is null)
            {
                throw new ProductNotFoundException(ProductId);
            }

            var cart = await repositoryManager.cart.GetCartForUser(user.Id, false);

            if(cart is not null)
            {
                bool productAlreadyInCart = cart.CartItems.Any(ci => ci.ProductId == ProductId);

                if (!productAlreadyInCart)
                {
                    var cartItem = new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = ProductId,
                        QuantityInCart = 1
                    };

                    repositoryManager.cartItem.AddToCart(cartItem);
                }
            }
            else
            {
                Cart newCart = new Cart
                {
                    userId = user.Id
                };

                repositoryManager.cart.CreateCart(newCart);

                var cartItem = new CartItem
                {
                    CartId = newCart.Id,
                    ProductId = ProductId
                };
                repositoryManager.cartItem.AddToCart(cartItem);
            }

            await repositoryManager.Save();
        }

        public async Task<List<CartItemDto>> GetCartProducts(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            var cart = await repositoryManager.cart.GetCartForUser(user.Id, false);

            if(cart is not null )
            {
                var products = await repositoryManager.cart.GetProductsInCart(user.Id, false);

                return products;
            }
            else
            {
                return null;
            }
        }
    }
}
