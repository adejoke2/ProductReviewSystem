using System.Collections.Generic;
using ProductReviewSystem.Models;

namespace ProductReviewSystem.Repositories
{
    public interface IProductRepository
    {
        public Product AddProduct(Product product);

        public Product FindById(int id);

        public Product UpdateProduct(Product product);

        public void Delete(int id);

        public List<Product> GetProducts();

        public List<Product> GetReviewProducts(int userId);


    }
}
