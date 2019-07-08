using Microsoft.AspNetCore.SignalR;
using PPChat.Models;
using PPChat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Hubs
{
    public class ChatHub: Hub
    {
        private MessageService _msgService;

        public ChatHub(MessageService messageService)
        {
            _msgService = messageService;
        }

        public async Task SendMessage(Message message)
        {
            //add message to db (actually better to let the client call a controller action to store the msg)...
            await Clients.All.SendAsync("ReceiveMessage", message);

        }
    }
}
