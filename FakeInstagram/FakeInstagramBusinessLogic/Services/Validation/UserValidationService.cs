using FakeInstagramEfModels.Entities;
using System;

namespace FakeInstagramBusinessLogic.Services.Validation
{
    public class UserValidationService : IUserValidationService
    {
        public void UserIsNullValidation(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }
    }
}
