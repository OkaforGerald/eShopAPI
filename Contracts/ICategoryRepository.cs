using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using SharedAPI.Data_Transfer;

namespace Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories(bool trackChanges);

        Task<Category> GetCategoryById(Guid Id, bool trackChanges);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);
    }
}
