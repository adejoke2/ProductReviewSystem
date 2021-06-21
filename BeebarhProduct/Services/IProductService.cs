using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;

namespace ProductReviewSystem.Services
{
    public interface IProductService
    {
        public Product AddProduct(CreateProductViewModel model);
     
        public void Delete(int id);

        public Product FindById(int id);

        public List<ProductViewModel> GetProducts();

        public List<Product> GetReviewProducts(int userId);

        public Product UpdateProduct(UpdateProductViewModel model);

        public IEnumerable<SelectListItem> GetProductList();

        public IEnumerable<SelectListItem> GetReviewProductList(int userId);
    }
}
