using FakeInstagramEfModels.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FakeInstagramViewModels.AuthorizationModels;

using FakeInstagramBusinessLogic.Repositories;
using FakeInstagramMigrations.Configurations;
using FakeInstagramBusinessLogic.Converters;
using FakeInstagramViewModels.CreateModels;
using FakeInstagramMigrations.CustomEntities;
using System.Threading.Tasks;

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

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _repository.GetUserByEmailAndPassword(model.Email, model.Password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
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

        public async Task<User> GetUserById(Guid id)
        {
            return await _repository.GetUserById(id);
        }

        // helper methods
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.GetAllUsers();
        }

        public async Task<AuthorizationIdentity> GetIdentityById(Guid id)
        {
            var user = await _repository.GetUserById(id);
            return _converter.ConvertToAuthorizationIdentity(user);
        }

        public TopUser SelectTopUserForSelectedMonth(DateTime selectedDate)
        {
            return _repository.SelectTopUserForSelectedMonth(selectedDate);
        }

        public List<UserLikes> SelectUsersWithLikesMoreThanAverage()
        {
            return _repository.SelectUsersWithLikesMoreThanAverage();
        }

        public async Task CreateUser(CreateUserModel userModel)
        {
            User user = _converter.ConvertToUser(userModel);
            await _repository.CreateUser(user);
        }
    }
}
