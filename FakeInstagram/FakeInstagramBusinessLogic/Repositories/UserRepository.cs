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

        public async Task CreateUser(User user)
        {
            user.UserRole = await _context.UserRoles.FirstOrDefaultAsync(role => role.Name.Equals("User"));
            user.IsVerified = false;
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> user = await _context.Users.ToListAsync();//.Include(post => post.Posts);
            return user;
        }

        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            User user = await _context.Users.Include(role => role.UserRole)
                .FirstOrDefaultAsync(currentUser => currentUser.Email.Equals(email) && currentUser.Password.Equals(password));
            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            User user = await _context.Users.Include(role => role.UserRole).FirstOrDefaultAsync(currentUser => currentUser.Id == id);
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
