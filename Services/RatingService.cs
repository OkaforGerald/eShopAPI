using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using SharedAPI.Data_Transfer;

namespace Services
{
    public class RatingService : IRatingService
    {
        private readonly UserManager<User> userManager;
        private readonly IRepositoryManager manager;

        public RatingService(IRepositoryManager manager, UserManager<User> userManager)
        {
            this.manager = manager;
            this.userManager = userManager;
        }

        public async Task CreateRating(string username, Guid StoreID, Guid ProductId, RatingAndReviewDto ratingAndReviewDto)
        {
            var user = await userManager.FindByNameAsync(username);

            if(user is null)
            {
                throw new Exception("User Not Found");
            }

            var product = await manager.products.GetProductById(StoreID, ProductId, false);
            if(product is null)
            {
                throw new Exception();
            }

            var review = await manager.rating.GetReviewsForProductsByUser(product.Id, user.Id, trackChanges: true);
            if(review is not null)
            {
                throw new Exception("You have reviewed this product already");
            }

            RatingAndReview newReview = new RatingAndReview()
            {
                ProductId = product.Id,
                userId = user.Id,
                Rating = ratingAndReviewDto.Rating,
                Review = ratingAndReviewDto.Review,
                CreatedAt = DateTime.Now
            };

            manager.rating.CreateReview(newReview);
            await manager.Save();
        }

        public async Task UpdateRating(string username, Guid StoreID, Guid ProductId, RatingAndReviewDto ratingAndReviewDto)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user is null)
            {
                throw new Exception();
            }

            var product = await manager.products.GetProductById(StoreID, ProductId, false);
            if (product is null)
            {
                throw new Exception("Product Not Found");
            }

            var review = await manager.rating.GetReviewsForProductsByUser(product.Id, user.Id, trackChanges: true);
            review.Rating = ratingAndReviewDto.Rating;
            review.Review = ratingAndReviewDto.Review;

            await manager.Save();
        }

        public async Task<ReviewResponseDto> GetReviewsByUser(string username, Guid StoreID, Guid ProductId)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user is null)
            {
                throw new Exception();
            }

            var product = await manager.products.GetProductById(StoreID, ProductId, false);
            if (product is null)
            {
                throw new Exception("Product Not Found");
            }

            var review = await manager.rating.GetReviewsForProductsByUser(product.Id, user.Id, trackChanges: false);
            ReviewResponseDto response = new ReviewResponseDto
            {
                Id = review.Id,
                CreatedAt = review.CreatedAt,
                UpdatedAt = review.CreatedAt,
                Review = review.Review,
                Rating = review.Rating,
                ReviewerName = $"{user.FirstName} {user.LastName}",
                ProductId = review.ProductId
            };
            return response;
        }

        public async Task<List<ReviewResponseDto>> GetReviewsForProduct(Guid StoreID, Guid ProductId)
        {
            var product = await manager.products.GetProductById(StoreID, ProductId, false);
            if (product is null)
            {
                throw new Exception("Product Not Found");
            }

            List<ReviewResponseDto> responses = new List<ReviewResponseDto>();
            var reviews = await manager.rating.GetReviewsForProduct(ProductId);

            foreach (var review in reviews) {

                var user = await userManager.FindByIdAsync(review.userId);

                if (user is null)
                {
                    throw new Exception();
                }

                ReviewResponseDto response = new ReviewResponseDto
                {
                    Id = review.Id,
                    CreatedAt = review.CreatedAt,
                    UpdatedAt = review.CreatedAt,
                    Review = review.Review,
                    Rating = review.Rating,
                    ReviewerName = $"{user.FirstName} {user.LastName}",
                    ProductId = review.ProductId
                };

                responses.Add(response);
            }

            return responses;
        }
    }
}
