using System.Collections.Generic;
using ProductReviewSystem.Models;

namespace ProductReviewSystem.Repositories
{
    public interface IReviewRepository
    {
        public Review AddReview(Review review);

        public Review FindById(int id);

        public List<Review> FindByProductId(int productId);

        public Review UpdateReview(Review review);

        public void Delete(int id);

        public List<Review> GetReviews();

        public List<Review> GetReviewsProduct(int productId);
        
    }
}
