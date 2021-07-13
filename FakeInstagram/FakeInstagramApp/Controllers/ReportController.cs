using FakeInstagramBusinessLogic.Services;
using FakeInstagramEfModels.Entities;
using FakeInstagramMigrations.CustomEntities;
using FakeInstagramViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeInstagramApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReportController : ControllerBase
    {
        private readonly IUserService _userService;

        public ReportController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{selectedDate}")]
        public IActionResult SelectTopUserForSelectedMonth(DateTime selectedDate)
        {
            TopUser topUserViewModel = _userService.SelectTopUserForSelectedMonth(selectedDate);
            return Ok(topUserViewModel);
        }

        [HttpGet]
        public IActionResult SelectUsersWithLikesMoreThanAverage()
        {
            List<UserLikes> topUserViewModel = _userService.SelectUsersWithLikesMoreThanAverage();
            return Ok(topUserViewModel);
        }
    }
}
