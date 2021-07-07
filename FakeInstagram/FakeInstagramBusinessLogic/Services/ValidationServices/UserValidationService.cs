using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Services.ValidationServices
{
    public class UserValidationService : IUserValidationService
    {
        public void ValidateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
        }
    }
}
