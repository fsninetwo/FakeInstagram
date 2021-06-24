﻿using FakeInstagramBusinessLogic.Services;
using FakeInstagramEfModels.Entities;
using FakeInstagramViewModels.AuthorizationModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FakeInstagramBusinessLogic.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _context;
        private readonly IUserService _userService;

        public CurrentUserProvider(IHttpContextAccessor context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public User GetCurrentUser()
        {
            try
            {
                Guid id = Guid.Parse(_context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                User user = _userService.GetById(id);
                return user;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }     
    }
}
