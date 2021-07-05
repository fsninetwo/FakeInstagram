using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramViewModels.UpdateModels;
using FakeInstagramViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Converters
{

    public interface IUserConverter
    {
        AuthorizationIdentity ConvertToAuthorizationIdentity(User user);
        User ConvertToUser(CreateUserModel userModel);
    }
}
