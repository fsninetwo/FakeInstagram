using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations.CustomEntities;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPassword(string email, string password);

        Task<User> GetUserById(Guid id);

        Task CreateUser(User user);

        Task<List<User>> GetAllUsers();

        TopUser SelectTopUserForSelectedMonth(DateTime selectedDate);

        List<UserLikes> SelectUsersWithLikesMoreThanAverage();
    }
}
