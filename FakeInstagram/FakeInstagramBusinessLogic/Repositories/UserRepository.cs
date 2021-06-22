using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
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

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> user = _context.Users;
            return user;
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            User user = _context.Users.FirstOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
            return user;
        }

        public User GetById(Guid id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);
            return user;
        }
    }
}
