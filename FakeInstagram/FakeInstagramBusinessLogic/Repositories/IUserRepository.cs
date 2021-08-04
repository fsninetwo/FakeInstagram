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
        User GetUserByEmailAndPassword(string email, string password);

        User GetUserById(Guid id);

        void CreateUser(User user);

        IEnumerable<User> GetAllUsers();

        TopUser SelectTopUserForSelectedMonth(DateTime selectedDate);

        List<UserLikes> SelectUsersWithLikesMoreThanAverage();
    }
}
