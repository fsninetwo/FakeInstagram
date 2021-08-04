using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramMigrations.CustomEntities;
using FakeInstagramViewModels.ViewModels;
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

        public IEnumerable<FakeInstagramEfModels.Entities.User> GetAllUsers()
        {
            IEnumerable<FakeInstagramEfModels.Entities.User> user = _context.Users;//.Include(post => post.Posts);
            return user;
        }

        public FakeInstagramEfModels.Entities.User GetUserByEmailAndPassword(string email, string password)
        {
            FakeInstagramEfModels.Entities.User user = _context.Users.Include(role => role.UserRole)
                .FirstOrDefault(user => user.Email.Equals(email) && user.Password.Equals(password));
            return user;
        }

        public User GetUserById(Guid id)
        {
            FakeInstagramEfModels.Entities.User user = _context.Users.Include(role => role.UserRole).FirstOrDefault(user => user.Id == id);
            return user;
        }

        public TopUser SelectTopUserForSelectedMonth(DateTime selectedDate)
        {
            var param = new Microsoft.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SelectedDate",
                SqlDbType = System.Data.SqlDbType.DateTime,
                Direction = System.Data.ParameterDirection.Output,
            };

            return _context.TopUsers.FromSqlRaw("[dbo].[UserWithMostLikesInMonth] @SelectedDate OUT", param).FirstOrDefault();
        }

        public List<UserLikes> SelectUsersWithLikesMoreThanAverage()
        {
            return _context.UserLikes.FromSqlRaw("[dbo].[UserWithMorePostLikesThanAverage]").ToList();
        }
    }
}
