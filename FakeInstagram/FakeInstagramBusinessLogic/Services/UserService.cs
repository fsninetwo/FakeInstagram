using FakeInstagramEfModels.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using FakeInstagramViewModels.AuthorizationModels;

using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramMigrations.Configurations;
using FakeInstagramBusinessLogic.Converters;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramBusinessLogic.Providers;

namespace FakeInstagramBusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IAppSettings _appSettings;
        private readonly IUserRepository _repository;
        private readonly IUserConverter _converter;

        public UserService(IAppSettings appSettings, IUserRepository repository, IUserConverter converter)
        {
            _appSettings = appSettings;
            _repository = repository;
            _converter = converter;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _repository.GetUserByEmailAndPassword(model.Email, model.Password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"User"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserRole.Name),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticateResponse(user, tokenHandler.WriteToken(token));
        }

        public User GetUserById(Guid id)
        {
            return _repository.GetUserById(id);
        }

        // helper methods
        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public AuthorizationIdentity GetIdentityById(Guid Id)
        {
            User user = _repository.GetUserById(Id);
            return _converter.ConvertToAuthorizationIdentity(user);
        }

        public void CreateUser(CreateUserModel userModel)
        {
            User user = _converter.ConvertToUser(userModel);
            _repository.CreateUser(user);
        }
    }
}
