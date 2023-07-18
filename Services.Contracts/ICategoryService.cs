using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories(bool trackChanges);

        Task<CategoryDto> GetCategoryById(Guid Id,  bool trackChanges);

        Task DeleteCategory(Guid Id);

        Task UpdateCategory(Guid Id, CreateCategoryDto category);

        Task<CategoryDto> CreateCategory(CreateCategoryDto category);

        Task<(IEnumerable<ProductsDto> products, Metadata metadata)> GetProducts(Guid CategoryId, ProductParameters parameters, bool trackChanges);
    }
}
