using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessages", message);
        }

        public async Task Send(string name, string message)
        {
            await Clients.All.addNewMessageToPage(name, message);
        }
    }
}