using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
