using FakeInstagramEfModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramViewModels.AuthorizationModels
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Role = user.UserRole.Name;
            Email = user.Email;
            Token = token;
        }
    }
}
