using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SharedAPI.Data_Transfer;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public async Task<IEnumerable<Category>> GetCategories(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Category> GetCategoryById(Guid Id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
