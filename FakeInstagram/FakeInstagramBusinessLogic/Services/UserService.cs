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
            User user = _repository.GetByEmailAndPassword(model.Email, model.Password);
            if (user == null) return null;
            string token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public User GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public AuthorizationIdentity GetIdentityById(Guid Id)
        {
            User user = _repository.GetById(Id);
            return _converter.ConvertToAuthorizationIdentity(user);
        }
    }
}
