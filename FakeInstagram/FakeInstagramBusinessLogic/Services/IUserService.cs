using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations.CustomEntities;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);

        Task<User> GetUserById(Guid id);

        Task<IEnumerable<User>> GetAllUsers();

        Task<AuthorizationIdentity> GetIdentityById(Guid userId);

        Task CreateUser(CreateUserModel userModel);
      
        TopUser SelectTopUserForSelectedMonth(DateTime selectedDate);

        List<UserLikes> SelectUsersWithLikesMoreThanAverage();
    }
}