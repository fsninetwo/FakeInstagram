using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramViewModels.AuthorizationModels
{
    public class AuthorizationIdentity
    {

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string UserRole { get; set; }


    }
}
