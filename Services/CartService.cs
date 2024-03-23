using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
                    ProductId = ProductId,
                    QuantityInCart = 1
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

        public async Task CheckoutCart(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            var cart = await GetCartProducts(username);
            HashSet<Guid> uniqueStores = new HashSet<Guid>();

            if(cart is not null)
            {
                foreach( var cartItem in cart)
                {
                    uniqueStores.Add(cartItem.Product.StoreId);
                }

                foreach(var store in uniqueStores)
                {
                    var matchedProducts = cart.Where(x => x.Product.StoreId == store).ToList();
                    var Order = new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        StoreId = store,
                        Buyer = username,
                        OrderPrice = matchedProducts.Sum(x => x.Product.Price),
                        OrderQuantity = matchedProducts.Sum(x => x.Product.Quantity)
                    };

                    repositoryManager.orders.CreateOrder(Order);

                    foreach (var products in matchedProducts) {
                        var prod = await repositoryManager.products.GetProductById(products.Product.StoreId, products.Product.Id, true);
                        prod.Quantity--;
                        var OrderProduct = new OrderProducts
                        {
                            OrderId = Order.Id,
                            ProductId = products.Product.Id,
                            QuantityOrdered = products.QuantityInCart
                        };
                        repositoryManager.orderProduct.CreateOrderProduct(OrderProduct);
                    }
                }
                var userCart = await repositoryManager.cart.GetCartForUser(user.Id, false);
                repositoryManager.cart.DeleteCart(userCart);
                await repositoryManager.Save();
            }
        }

        public async Task<List<OrderProductDto>> GetUserOrdersAsync(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            var store = await repositoryManager.stores.GetStoreByOwnerId(user.Id, false);
            var receivedOrders = new List<Order>();
            var orders = new List<Order>();
            if (store != null)
            {
                receivedOrders = await repositoryManager.orders.GetOrdersForUserStore(store.Id, false);
            }

            orders = await repositoryManager.orders.GetOrdersByUser(username, false);

            var userOrders = orders.Concat(receivedOrders).ToList();

            var orderProductDtos = userOrders.Select(o => new OrderProductDto
            {
                Id = o.Id,
                Buyer = o.Buyer,
                OrderSummary = o.OrderProducts.Select(op => $"{op.Product.Name} x {op.QuantityOrdered} x {op.Product.Price}").Aggregate((a, b) => $"{a}, {b}"),
                OrderDate = o.CreatedAt,
                Price = o.OrderPrice
            }).ToList();

            return orderProductDtos;
        }

        public async Task<OrderProductDto> GetUserOrderById(string username, Guid Id)
        {
            var user = await userManager.FindByNameAsync(username);
            var store = await repositoryManager.stores.GetStoreByOwnerId(user.Id, false);
            var receivedOrders = new List<Order>();
            var orders = new List<Order>();
            if (store != null)
            {
                receivedOrders = await repositoryManager.orders.GetOrdersForUserStore(store.Id, false);
            }

            orders = await repositoryManager.orders.GetOrdersByUser(username, false);

            var userOrders = orders.Concat(receivedOrders).ToList();

            var matchedOrder = userOrders.Where(x => x.Id == Id).FirstOrDefault();
            if (matchedOrder != null)
            {
                var buyer = await userManager.FindByEmailAsync(matchedOrder.Buyer);
                var orderProductDtos = new OrderProductDto
                {
                    Id = matchedOrder.Id,
                    SellerName = store.Name,
                    SellerLocation = store.Address,
                    SellerPhone = store.PhoneNumber,
                    Buyer = $"{buyer.FirstName} {buyer.LastName}",
                    BuyerNumber = buyer.PhoneNumber,
                    OrderSummary = matchedOrder.OrderProducts.Select(op => $"{op.Product.Name} x {op.QuantityOrdered} x {op.Product.Price}").Aggregate((a, b) => $"{a}, {b}"),
                    OrderDate = matchedOrder.CreatedAt,
                    Price = matchedOrder.OrderPrice
                };

                return orderProductDtos;
            }
            else
            {
                return null;
            }
        }

        //public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        //{
        //    var item = await repositoryManager.cart.GetCartForUser()
        //}
    }
}
