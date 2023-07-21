using System;
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
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public CategoryService(IRepositoryManager manager, IMapper mapper)
        {
            this.repositoryManager = manager;
            this.mapper = mapper;
        }
        public async Task<CategoryDto> CreateCategory(CreateCategoryDto category)
        {
            var categoryDto = mapper.Map<Category>(category);

            repositoryManager.category.CreateCategory(categoryDto);
            await repositoryManager.Save();

            var response = mapper.Map<CategoryDto>(categoryDto);
            return response;
        }

        public async Task DeleteCategory(Guid Id)
        {
            var category = await repositoryManager.category.GetCategoryById(Id, trackChanges: false);

            if (category == null)
            {
                throw new CategoryNotFoundException(Id);
            }

            repositoryManager.category.DeleteCategory(category);
            await repositoryManager.Save();
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories(bool trackChanges)
        {
            var categories = await repositoryManager.category.GetCategories(trackChanges);

            var response = mapper.Map<IEnumerable<CategoryDto>>(categories);

            return response;
        }

        public async Task<CategoryDto> GetCategoryById(Guid Id, bool trackChanges)
        {
            var category = await repositoryManager.category.GetCategoryById(Id, trackChanges);

            if(category is null)
            {
                throw new CategoryNotFoundException(Id);
            }

            var response = mapper.Map<CategoryDto>(category);

            return response;
        }

        public async Task<(IEnumerable<ProductsDto> products, Metadata metadata)> GetProducts(Guid CategoryId, ProductParameters parameters, bool trackChanges)
        {
            var category = await repositoryManager.category.GetCategoryById(CategoryId, trackChanges: false);

            if (category is null)
            {
                throw new CategoryNotFoundException(CategoryId);
            }

            var products = await repositoryManager.products.GetProductsByCategory(CategoryId, parameters, trackChanges: false);

            var result = mapper.Map<IEnumerable<ProductsDto>>(products);

            return (products: result, metadata: products.Metadata);
        }

        public async Task UpdateCategory(Guid Id, CreateCategoryDto categoryDto)
        {
            var category = await repositoryManager.category.GetCategoryById(Id, trackChanges: true);

            if (category is null)
            {
                throw new CategoryNotFoundException(Id);
            }

            mapper.Map(categoryDto, category);
            await repositoryManager.Save();
        }
    }
}
