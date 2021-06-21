using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using ProductReviewSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewSystem.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public ReviewService(IReviewRepository reviewRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }


        public Review AddReview(CreateReviewViewModel model)
        {
            var review = new Review
            {
                UserId = model.UserId,
                ProductId = model.ProductId,
                Comment = model.Comment,
                Ratings = model.Ratings,
            };
            return _reviewRepository.AddReview(review);
        }

       
        public void Delete(int id)
        {
            _reviewRepository.Delete(id);
        }

        public Review FindById(int id)
        {
            return _reviewRepository.FindById(id);
        }

        public List<Review> FindByProductId (int productId)
        {
            return _reviewRepository.FindByProductId(productId);
        }
        public List<ReviewViewModel> GetReviews()
        {
            var reviews = _reviewRepository.GetReviews().Select(r => new ReviewViewModel
            {
                Id = r.Id,
                Comment = r.Comment,
                Ratings = r.Ratings,
                UserId = r.UserId,
                ProductId = r.ProductId
            }).ToList();

            return reviews;
        }
        public List<ProductIndexViewModel> GetReviewsProduct(int productId)
        {
            var reviews = _reviewRepository.GetReviewsProduct(productId).Select(r => new ProductIndexViewModel
            {
                Id = r.Id,
                Comment = r.Comment,
                Ratings = r.Ratings,
                UserName = _userRepository.FindById(r.UserId).Name,
                ProductName = _productRepository.FindById(r.ProductId).Name
            }).ToList();
            return reviews;
        }

        public Review UpdateReview(UpdateReviewViewModel model)
        {
            var review = _reviewRepository.FindById(model.Id);
            review.Comment = model.Comment;
            review.Ratings = model.Ratings;
            return _reviewRepository.UpdateReview(review);
        }

    }
}