using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using ProductReviewSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductReviewSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReviewRepository _reviewRepository;

        public ProductService(IProductRepository productRepository, IUserRepository userRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
        }
        public Product AddProduct(CreateProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                UserId = model.UserId,
                CreatedAt = DateTime.Now
            };

            return _productRepository.AddProduct(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public Product FindById(int id)
        {
            return _productRepository.FindById(id);
        }

        public IEnumerable<SelectListItem> GetProductList()
        {
            return GetProducts().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetReviewProductList(int userId)
        {
            return GetReviewProducts(userId).Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        public double GetAverageRating(int productId)
        {
            var reviews = _reviewRepository.FindByProductId(productId);
            double sum = 0;
            if (reviews.Count == 0) return 0;
            foreach(var review in reviews)
            {
                sum += review.Ratings;
            }
            double totalaverage = sum /reviews.Count;
            return totalaverage;
        }
        public List<ProductViewModel> GetProducts()
        {
            var products = _productRepository.GetProducts().Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UserName = _userRepository.FindById(p.UserId).Name,
                AverageRating = GetAverageRating(p.Id)
            }).ToList();

            return products;
        }

        public List<Product> GetReviewProducts(int userId)
        {
            var products = _productRepository.GetReviewProducts(userId);
            return products;
        }

        public Product UpdateProduct(UpdateProductViewModel model)
        {
            var product = _productRepository.FindById(model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
           
            return _productRepository.UpdateProduct(product);
        }
    }
}
