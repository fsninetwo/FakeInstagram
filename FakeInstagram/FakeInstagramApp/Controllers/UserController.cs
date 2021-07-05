//using FakeInstagramApp.Attributes;
using FakeInstagramBusinessLogic.Providers;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramViewModels.AuthorizationModels;
using FakeInstagramViewModels.CreateModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly ILogger<UserController> _logger;

        public UserController (IUserService userService, ICurrentUserProvider currentUserProvider, ILogger<UserController> logger)
        {
            _userService = userService;
            _currentUserProvider = currentUserProvider;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            _logger.LogInformation("User made a GetUsers request");
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserModel userModel)
        {
            _userService.CreateUser(userModel);
            return Ok(userModel);
        }
    }
}
