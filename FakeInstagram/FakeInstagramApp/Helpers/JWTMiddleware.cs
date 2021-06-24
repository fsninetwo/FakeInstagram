using FakeInstagramBusinessLogic.Services;
using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations.Configurations;
using FakeInstagramViewModels.AuthorizationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramApp.Helpers
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAppSettings _appSettings;

        public JWTMiddleware(RequestDelegate next, IAppSettings appSettings)
        {
            _next = next;
            _appSettings = appSettings;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                attachUserToContext(context, userService, token);
            }

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                TokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                AuthorizationIdentity identity = userService.GetIdentityById(userId);

                var user = new ClaimsPrincipal(
                    new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "User"),
                        new Claim(ClaimTypes.NameIdentifier, identity.Id.ToString()),
                        new Claim(ClaimTypes.Email, identity.Email),
                        new Claim(ClaimTypes.Role, identity.UserRole),
                    }, "tokenAuthorization"));
                context.User = user;

                //context.Items["User"] = userService.GetById(userId);
            }
            catch
            {

            }
        }
    }
}
