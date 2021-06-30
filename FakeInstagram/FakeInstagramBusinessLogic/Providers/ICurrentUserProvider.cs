using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.AuthorizationModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Providers
{
    public interface ICurrentUserProvider
    {
        User GetCurrentUser();

        bool IsCurrentUserVerified();

        bool IsCurrentUserAdministrator();
    }
}
