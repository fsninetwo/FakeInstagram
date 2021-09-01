using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FakeInstagramBusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeInstagramApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            await _messageService.SendMessageAsync(message, "notifyqueue");
            return Ok();
        }
    }
}
