using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FakeInstagramContext _context;

        public UserRepository(FakeInstagramContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreateUser(User user)
        {
            user.UserRole = _context.UserRoles.FirstOrDefault(role => role.Name.Equals("User"));
            user.IsVerified = false;
            _context.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> user = _context.Users;//.Include(post => post.Posts);
            return user;
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            User user = _context.Users.FirstOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
            return user;
        }

        public User GetUserById(Guid id)
        {
            User user = _context.Users.Include(role => role.UserRole).FirstOrDefault(user => user.Id == id);
            return user;
        }
    }
}
