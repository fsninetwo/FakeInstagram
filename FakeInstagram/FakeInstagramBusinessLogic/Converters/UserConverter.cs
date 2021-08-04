using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;
using System;

namespace FakeInstagramBusinessLogic.Converters
{
    public class UserConverter : IUserConverter
    {
        public AuthorizationIdentity ConvertToAuthorizationIdentity(User user)
        {
            AuthorizationIdentity identity = new AuthorizationIdentity()
            {
                Id = user.Id,
                Email = user.Email,
                UserRole = user.UserRole.Name
            };
            return identity;
        }

        public User ConvertToUser(CreateUserModel userModel)
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                Email = userModel.Email,
                Password = userModel.Password
            };
            return user;
        }
    }
}
