using ProductReviewSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewSystem.Repositories
{
    public interface IUserRepository
    {
        public User AddUser(User user);

        public User FindById(int id);

        public User UpdateUser(User user);

        public void Delete(int id);

        public List<User> GetUsers();
       
    }
}
