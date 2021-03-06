using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
