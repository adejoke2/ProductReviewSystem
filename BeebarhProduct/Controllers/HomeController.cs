using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using ProductReviewSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly IReviewService _reviewService;
        private readonly IProductService _productService;

        public HomeController(IReviewService reviewService, IProductService productService)
        {
            _reviewService = reviewService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Detail(ProductViewModel model)
        {
            Console.WriteLine(model.Id);
            var review = _reviewService.GetReviewsProduct(model.Id); 
            if(review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
