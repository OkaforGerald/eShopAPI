﻿using System;
using System.Collections.Generic;
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

        public async Task<ProductsDto> CreateProduct(Guid StoreID, string imageUrl, ProductCreationDto productDto)
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
    }
}