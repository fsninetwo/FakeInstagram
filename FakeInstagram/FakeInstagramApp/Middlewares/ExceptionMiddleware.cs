using FakeInstagramBusinessLogic.Exceptions;
using FakeInstagramBusinessLogic.Services;
using FakeInstagramMigrations.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FakeInstagramApp.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(PostValidationException PostEx)
            {
                await HandleExceptionAsync(context, PostEx, HttpStatusCode.BadRequest);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode httpStatus)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatus;
            await context.Response.WriteAsync(new ErrorModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }
    }
}
