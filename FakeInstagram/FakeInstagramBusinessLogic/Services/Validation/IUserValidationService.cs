using FakeInstagramEfModels.Entities;

namespace FakeInstagramBusinessLogic.Services.Validation
{
    public interface IUserValidationService
    {
        void UserIsNullValidation(User user);
    }
}
