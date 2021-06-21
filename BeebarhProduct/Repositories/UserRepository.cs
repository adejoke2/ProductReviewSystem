using ProductReviewSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewSystem.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ProductDbContext _dbContext;

        public UserRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User FindById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var user = FindById(id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
