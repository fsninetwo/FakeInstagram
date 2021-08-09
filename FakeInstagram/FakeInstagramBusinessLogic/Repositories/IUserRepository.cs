using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations.CustomEntities;
using System;
using System.Collections.Generic;
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
