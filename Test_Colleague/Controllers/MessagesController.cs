using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Colleague.Data;
using Test_Colleague.IRepository;
using Test_Colleague.Models;
using Test_Colleague.ViewModels;

namespace Test_Colleague.Controllers
{
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessageServices _messageService;

        private readonly IHubContext<MessageCenterHub> _hub;

        public MessagesController(IMessageServices messageServices, IHubContext<MessageCenterHub> hub)
        {
            _messageService = messageServices;

            _hub = hub;
        }

        [HttpGet]
        [Route("api/Messages")]
        public async Task<IEnumerable<TMessage>> GetMessagessAsync()
        {
            return await _messageService.GetMessagesAsync();
        }

        [HttpGet]
        [Route("api/Notifications")]
        public async Task<int> GetNotificationAsync()
        {
            return await _messageService.GetNotificationAsync(1);
        }

        [HttpPost]
        [Route("api/Messages")]
        public async Task SendMessagesAsync(SendMessagesDto model)
        {
            await _messageService.SendMessagesAsync(model);

            await _hub.Clients.All.SendAsync("RefreshMessageCentre");
        }
    }
}
