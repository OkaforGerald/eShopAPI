using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IRatingRepository
    {
        void CreateReview(RatingAndReview ratingAndReview);
        void DeleteReview(RatingAndReview ratingAndReview);
        Task<List<RatingAndReview>> GetReviewsForProduct(Guid ProductId);
        Task<RatingAndReview> GetReviewsForProductsByUser(Guid ProductId, string userId, bool trackChanges);
    }
}
