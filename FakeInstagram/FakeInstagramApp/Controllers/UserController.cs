using FakeInstagramApp.Attributes;
using FakeInstagramBusinessLogic.Providers;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserProvider _currentUserProvider;

        public UserController (IUserService userService, ICurrentUserProvider currentUserProvider)
        {
            _userService = userService;
            _currentUserProvider = currentUserProvider;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            if (_currentUserProvider.IsCurrentUserAdministrator())
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            else
            {
                return BadRequest("User is not administrator!");
            }
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserModel userModel)
        {
            _userService.CreateUser(userModel);
            return Ok(userModel);
        }
    }
}
