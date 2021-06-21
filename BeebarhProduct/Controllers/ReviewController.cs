using Microsoft.AspNetCore.Mvc;
using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using ProductReviewSystem.Services;
using System;
using System.Collections.Generic;

namespace ProductReviewSystem.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ReviewController(IReviewService reviewService, IProductService productService, IUserService userService)
        {
            _reviewService = reviewService;
            _productService = productService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductIndexViewModel> productIndexVM = new List<ProductIndexViewModel>();

            var reviews = _reviewService.GetReviews();

            foreach (var review in reviews)
            {
                ProductIndexViewModel productIndex = new ProductIndexViewModel
                {
                    Id = review.Id,
                    Comment = review.Comment,
                    Ratings = review.Ratings,
                    UserName = _userService.FindById(review.UserId).Name,
                    ProductName = _productService.FindById(review.ProductId).Name,
                };

                productIndexVM.Add(productIndex);
            }
            return View(productIndexVM);
        }

        [HttpGet]
        public IActionResult SelectUser()
        {
            ViewBag.users = _userService.GetUserList();
            ViewBag.products = _productService.GetProductList();
            var model = new SelectUserViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SelectUser(SelectUserViewModel model)
        {
            return RedirectToAction(nameof(Create), new { userId= model.UserId});
        }

        [HttpGet]
        public IActionResult Create(int userId)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Create(CreateReviewViewModel model)
        {
            var userId = model.UserId;

            User user = _userService.FindById(userId);

            if (user == null || userId == 0) return RedirectToAction(nameof(Index));

            ViewBag.products = _productService.GetReviewProductList(userId);

            ViewBag.UserId = user.Name;
            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitReview(CreateReviewViewModel model)
        {
            Console.WriteLine("user Id is : "+model.UserId);
            Console.WriteLine("product Id is : " + model.ProductId);
            _reviewService.AddReview(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        // public IActionResult Detail(int id)
        // {
        //     var review = _reviewService.FindById(id);
        //     if (review == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(review);
        // }


        public IActionResult Update(int id)
        {
            var review = _reviewService.FindById(id);
            if (review == null)
            {
                return NotFound();
            }
            else
            {
                return View(review);
            }
        }

        [HttpPost]
        public IActionResult Update(UpdateReviewViewModel model)
        {

            _reviewService.UpdateReview(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var review = _reviewService.FindById(id);
            if (review == null)
            {
                return NotFound();
            }
            _reviewService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
