using ProductReviewSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewSystem.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ProductDbContext _dbContext;

        public ReviewRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Review AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return review;
        }

        public Review FindById(int id)
        {
            return _dbContext.Reviews.Find(id);
        }

        public List<Review> FindByProductId(int productId)
        {
            return _dbContext.Reviews.Where(review => review.ProductId == productId).ToList();
        }

        public Review UpdateReview(Review review)
        {
            _dbContext.Reviews.Update(review);
            _dbContext.SaveChanges();
            return review;
        }

        public void Delete(int id)
        {
            var review = FindById(id);

            if (review != null)
            {
                _dbContext.Reviews.Remove(review);
                _dbContext.SaveChanges();
            }
        }

        public List<Review> GetReviews()
        {
            return _dbContext.Reviews.ToList();
        }

        public List<Review> GetReviewsProduct(int productId)
        {
            return _dbContext.Reviews.Where(review=> review.ProductId == productId).ToList();
        }
    }
}

