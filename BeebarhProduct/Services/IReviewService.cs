using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using System.Collections.Generic;

namespace ProductReviewSystem.Services
{
    public interface IReviewService
    {
        public Review AddReview(CreateReviewViewModel model);

        public void Delete(int id);

        public Review FindById(int id);

        public List<Review> FindByProductId(int productId);

        public List<ReviewViewModel> GetReviews();

        public Review UpdateReview(UpdateReviewViewModel model);

        public List<ProductIndexViewModel> GetReviewsProduct(int productId);
       
    }
}
