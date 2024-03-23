using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using SharedAPI.Data_Transfer;

namespace Services.Contracts
{
    public interface IRatingService
    {
        Task CreateRating(string username, Guid StoreID, Guid ProductId, RatingAndReviewDto ratingAndReviewDto);

        Task UpdateRating(string username, Guid StoreID, Guid ProductId, RatingAndReviewDto ratingAndReviewDto);

        Task<ReviewResponseDto> GetReviewsByUser(string username, Guid StoreID, Guid ProductId);

        Task<List<ReviewResponseDto>> GetReviewsForProduct(Guid StoreID, Guid ProductId);
    }
}
