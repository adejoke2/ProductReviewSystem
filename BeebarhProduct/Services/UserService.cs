using Microsoft.AspNetCore.Mvc.Rendering;
using ProductReviewSystem.Models;
using ProductReviewSystem.Models.ViewModels;
using ProductReviewSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductReviewSystem.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User AddUser(CreateUserViewModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Gender = model.Gender,
                CreatedAt = DateTime.Now
            };

            return _userRepository.AddUser(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User FindById(int id)
        {
            return _userRepository.FindById(id);
        }

        public IEnumerable<SelectListItem> GetUserList()
        {
            return _userRepository.GetUsers().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            }).ToList();

        }
        
        public List<UserViewModel> GetUsers()
        {
            var users = _userRepository.GetUsers().Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Gender = u.Gender,
            }).ToList();

            return users;
        }
        
    }
}