using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPChat.Models;
using PPChat.Services;

namespace PPChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private MessageService _messageService;

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: api/Messages
        [HttpGet]
        public IEnumerable<Message> Get() => _messageService.Get();

        [HttpPost("Add")]
        public Message Add(Message m)
        {
            m.CreationTime = DateTime.Now;
            return _messageService.Create(m);
        }
    }
}
