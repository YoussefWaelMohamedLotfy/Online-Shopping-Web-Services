using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Online_Shopping_Service.Hubs
{
    public class CounterHub : Hub
    {
        static long counter = 0;

        public override Task OnConnected()
        {
            counter++;
            Clients.All.UpdateCount(counter);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            counter--;
            Clients.All.UpdateCount(counter);
            return base.OnDisconnected(stopCalled);
        }
    }
}