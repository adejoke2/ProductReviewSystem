using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using ProductReviewSystem.Services;

namespace ProductReviewSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(model);
                return RedirectToAction("Index");
            }
            return NotFound();
        } 

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var user = _userService.FindById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.FindById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
