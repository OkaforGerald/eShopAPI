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
using Services.Contracts;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public ProductService(IMapper mapper, IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<ProductsDto> CreateProduct(Guid StoreID, string imageUrl, ProductModifyingDto productDto)
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

            var response = mapper.Map<ProductsDto>(product);

            return response;
        }

        public async Task<ProductsDto> GetProductById(Guid StoreId, Guid ProductId, bool trackChanges)
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

            var result = mapper.Map<ProductsDto>(product);
            return result;
        }

        public async Task<(IEnumerable<ProductsDto> products, Metadata metadata)> GetProducts(Guid StoreId, ProductParameters parameters, bool trackChanges)
        {
            var store = await repositoryManager.stores.GetStoreById(StoreId, trackChanges: false);

            if(store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }

            var products = await repositoryManager.products.GetProducts(StoreId, parameters, trackChanges: false);

            var result = mapper.Map<IEnumerable<ProductsDto>>(products);

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

        public async Task DeleteProducts(Guid StoreId, Guid ProductId, bool trackChanges)
        {
            var store = await repositoryManager.stores.GetStoreById(StoreId, false);

            if(store is null)
            {
                throw new StoreNotFoundException(StoreId);
            }

            var product = await repositoryManager.products.GetProductById(StoreId, ProductId, false);

            if(product is null)
            {
                throw new StoreNotFoundException(ProductId);
            }

            var filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\" + product.ImageUrl.Substring(product.ImageUrl.IndexOf('I')).Replace("/","\\");
            
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            repositoryManager.products.DeleteProduct(product);
        }

        public async Task UpdateProduct(Guid StoreId, Guid ProductId, string imageUrl, ProductModifyingDto productDto)
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

            if (!product.ImageUrl.Contains(productDto.Image.FileName) && File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            mapper.Map(productDto, product);
            product.ImageUrl = imageUrl;
            await repositoryManager.Save();
        }
    }
}
