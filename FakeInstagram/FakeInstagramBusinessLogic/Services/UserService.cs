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
using FakeInstagramBusinessLogic.Helpers;
using FakeInstagramBusinessLogic.Repositories;

namespace FakeInstagramBusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _repository;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository repository)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
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
    }
}
