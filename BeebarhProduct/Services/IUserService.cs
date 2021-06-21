using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using System.Collections.Generic;

namespace ProductReviewSystem.Services
{
    public interface IUserService
    {
        public User AddUser(CreateUserViewModel model);

        public void Delete(int id);

        public User FindById(int id);

        public List<UserViewModel> GetUsers();

        public IEnumerable<SelectListItem> GetUserList();

    }
}
