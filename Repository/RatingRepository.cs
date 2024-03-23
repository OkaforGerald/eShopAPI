using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RatingRepository : RepositoryBase<RatingAndReview>, IRatingRepository
    {
        public RatingRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CreateReview(RatingAndReview ratingAndReview)
        {
            Create(ratingAndReview);
        }

        public void DeleteReview(RatingAndReview ratingAndReview)
        {
            Delete(ratingAndReview);
        }

        public async Task<List<RatingAndReview>> GetReviewsForProduct(Guid ProductId)
        {
            return await FindByCondition(x => x.ProductId == ProductId, false)
                .ToListAsync();
        }

        public async Task<RatingAndReview> GetReviewsForProductsByUser(Guid ProductId, string userId, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductId == ProductId && x.userId == userId, trackChanges)
                .FirstOrDefaultAsync();
        }
    }
}
