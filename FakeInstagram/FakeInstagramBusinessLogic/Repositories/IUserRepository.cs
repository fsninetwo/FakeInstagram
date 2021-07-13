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
        FakeInstagramEfModels.Entities.User GetUserByEmailAndPassword(string email, string password);

        FakeInstagramEfModels.Entities.User GetUserById(Guid id);

        void CreateUser(FakeInstagramEfModels.Entities.User user);

        IEnumerable<FakeInstagramEfModels.Entities.User> GetAllUsers();

        TopUser SelectTopUserForSelectedMonth(DateTime selectedDate);

        List<UserLikes> SelectUsersWithLikesMoreThanAverage();
    }
}
