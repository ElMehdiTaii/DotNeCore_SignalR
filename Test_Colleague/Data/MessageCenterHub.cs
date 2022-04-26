using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Colleague.Data
{
    public class MessageCenterHub : Hub
    {
        public async Task SendMessages()
        {
            await Clients.All.SendAsync("RefreshMessageCentre");
        }
    }
}
