using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.AuthorizationModels;
using System;
using System.Collections.Generic;

namespace FakeInstagramBusinessLogic.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        User GetById(Guid id);

        IEnumerable<User> GetAll();
    }
}