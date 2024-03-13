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
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ProductService(IMapper mapper, IRepositoryManager repositoryManager, UserManager<User> userManager)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<OrderProducsDto> CreateProduct(Guid StoreID, string username, string imageUrl, ProductModifyingDto productDto)
        {
            var user = await userManager.FindByNameAsync(username);
            var store = await repositoryManager.stores.GetStoreByOwnerId(user.Id, trackChanges: false);
            if(store.Id  == StoreID)
            {
                var product = new Product
                {
                    StoreId = StoreID,
                    ImageUrl = imageUrl,
                    Price = productDto.Price,
                    Quantity = productDto.Quantity,
                    Brand = productDto.Brand,
                    Description = productDto.Description,
                    Name = productDto.Name,
                    CategoryId = productDto.CategoryId,
                };

                repositoryManager.products.CreateProduct(product);
                await repositoryManager.Save();

                var response = mapper.Map<OrderProducsDto>(product);

                return response;
            }
            else
            {
                throw new Exception("Not authorized to create a product in this store");
            }
        }

        public async Task<OrderProducsDto> GetProductById(Guid StoreId, Guid ProductId, bool trackChanges)
        {
            var store = await repositoryManager.stores.GetStoreById(StoreId, trackChanges);

            if(store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }

            var product = await repositoryManager.products.GetProductById(StoreId, ProductId, trackChanges);
            
            if(product is null)
            {
                throw new ProductNotFoundException(ProductId);
            }

            var result = mapper.Map<OrderProducsDto>(product);
            result.Store = store.Name;
            return result;
        }

        public async Task<(IEnumerable<OrderProducsDto> products, Metadata metadata)> GetProducts(Guid StoreId, string username, ProductParameters parameters, bool trackChanges)
        {
            var store = await repositoryManager.stores.GetStoreById(StoreId, trackChanges: false);
            var user = await userManager.FindByNameAsync(username);
            bool canAct;

            if (store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }

            var userStore = await repositoryManager.stores.GetStoreByOwnerId(user.Id, false);

            if (userStore != null)
            {
                canAct = userStore.Id.Equals(store.Id);
            }
            else
            {
                canAct = false;
            }

            var products = await repositoryManager.products.GetProducts(StoreId, parameters, trackChanges: false);

            if (!products.Any())
            {
                var response = new OrderProducsDto();
                response.canAct = canAct;
                return (products: new List<OrderProducsDto> { response }, metadata: products.Metadata);
            }

            var result = mapper.Map<IEnumerable<OrderProducsDto>>(products);

            foreach(var product in result)
            {
                product.canAct = canAct;
                product.Store = store.Name;
            }

            return (products: result, metadata: products.Metadata);

        }

        public async Task<(string text, string recipient)> GenerateWhatsappText(Guid StoreId, Guid ProductId)
        {
            var store = await repositoryManager.stores.GetStoreById(StoreId, false);
                                                                                                       
            if (store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }

            var products = await repositoryManager.products.GetProductById(StoreId, ProductId, trackChanges: false);

            string text = $"Good day, I'll like to place an order for:\r\n\tProduct : {products.Name},\r\n\tDescription: {products.Description},\r\n\tBrand: {products.Brand},\r\n\tPrice: {products.Price},\r\n\tQuantity: 1,\r\n\r\nLink: ProdLink";
            string recipient = store.PhoneNumber.Replace("+", "").Trim();

            return (text, recipient);
        }

        public async Task<(Product products, string recipient)> GenerateEmailText(Guid StoreId, Guid ProductId)
        {
            var store = await repositoryManager.stores.GetStoreById(StoreId, false);

            if (store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }

            var products = await repositoryManager.products.GetProductById(StoreId, ProductId, trackChanges: false);

            string? recipient = store.Email;

            return (products, recipient);
        }

        public async Task DeleteProducts(Guid StoreId, Guid ProductId, string username, bool trackChanges)
        {
            var user = await userManager.FindByNameAsync(username);
            var storeFromUser = await repositoryManager.stores.GetStoreByOwnerId(user.Id, trackChanges: false);

            if ((storeFromUser != null && storeFromUser.Id == StoreId) || await userManager.IsInRoleAsync(user, "Administrator"))
            {

                var store = await repositoryManager.stores.GetStoreById(StoreId, false);

                if (store is null)
                {
                    throw new StoreNotFoundException(StoreId);
                }

                var product = await repositoryManager.products.GetProductById(StoreId, ProductId, false);

                if (product is null)
                {
                    throw new StoreNotFoundException(ProductId);
                }

                var filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\" + product.ImageUrl.Substring(product.ImageUrl.IndexOf('I')).Replace("/", "\\");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                repositoryManager.products.DeleteProduct(product);
            }
            else
            {
                throw new Exception("Not authorized to delete a product in this store");
            }
        }

        public async Task UpdateProduct(Guid StoreId, Guid ProductId, string username, string imageUrl, ProductModifyingDto productDto)
        {
            var user = await userManager.FindByNameAsync(username);
            var storeFromUser = await repositoryManager.stores.GetStoreByOwnerId(user.Id, trackChanges: false);

            if ((storeFromUser != null && storeFromUser.Id == StoreId) || await userManager.IsInRoleAsync(user, "Administrator"))
            {
                var store = await repositoryManager.stores.GetStoreById(StoreId, false);

                if (store is null)
                {
                    throw new StoreNotFoundException(StoreId);
                }

                var product = await repositoryManager.products.GetProductById(StoreId, ProductId, true);

                if (product is null)
                {
                    throw new StoreNotFoundException(ProductId);
                }

                var filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\" + product.ImageUrl.Substring(product.ImageUrl.IndexOf('I')).Replace("/", "\\");

                //if (!product.ImageUrl.Contains(productDto.Image.FileName) && File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}

                mapper.Map(productDto, product);
                product.ImageUrl = imageUrl;
                await repositoryManager.Save();
            }
            else
            {
                throw new Exception("Not authorized to update a product in this store");
            }
        }
    }
}
