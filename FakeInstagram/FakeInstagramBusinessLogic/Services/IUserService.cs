using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations.CustomEntities;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetUserById(Guid id);

        IEnumerable<User> GetAllUsers();

        AuthorizationIdentity GetIdentityById(Guid userId);

        void CreateUser(CreateUserModel userModel);
      
        TopUser SelectTopUserForSelectedMonth(DateTime selectedDate);

        List<UserLikes> SelectUsersWithLikesMoreThanAverage();
    }
}