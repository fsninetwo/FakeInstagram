using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;

namespace FakeInstagramBusinessLogic.Converters
{

    public interface IUserConverter
    {
        AuthorizationIdentity ConvertToAuthorizationIdentity(FakeInstagramEfModels.Entities.User user);
        User ConvertToUser(CreateUserModel userModel);
    }
}
