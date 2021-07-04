using FakeInstagramBusinessLogic.Providers;
using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.AuthorizationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace FakeInstagramApp.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter, IAuthorizeData
    {
        public string Policy { get; set; }
        public string Roles { get; set; }
        public string AuthenticationSchemes { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User;
            
            if (identity.Identity.Name == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            
            if (Roles != null)
            {
                //GenericPrincipal genericPrincipal = new GenericPrincipal(identity.Identity, roles);
                //genericPrincipal.IsInRole(Roles);

                string[] roles = Roles.Trim().Split(",");
                if (roles.Contains(identity.FindFirst(ClaimTypes.Role).Value))
                {
                    context.Result = new JsonResult(new { message = "User role is not permitted." })
                    {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                }
            }
        }
    }
}
