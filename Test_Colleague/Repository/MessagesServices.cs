using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Colleague.IRepository;
using Test_Colleague.Models;
using Test_Colleague.ViewModels;

namespace Test_Colleague.Repository
{
    public class MessagesServices : IMessageServices
    {
        private readonly DB_COLLEAGUEContext _context;

        public MessagesServices(DB_COLLEAGUEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TMessage>> GetMessagesAsync()
        {
            var messages = await _context.TMessages.ToListAsync();

            return messages;
        }

        public async Task<int> GetNotificationAsync(int UserId)
        {
            return await _context.TMessages.Where(a => a.IsRead == false && UserId == 1).CountAsync();
        }

        public async Task SendMessagesAsync(SendMessagesDto model)
        {
            TMessage message = new TMessage()
            {

                MessageContent = model.MessageContent,

                MessageObject = model.MessageObject,

                CreatedDate = model.CreatedDate,

                IsRead = false,

                UserId = 1

            };

            _context.Add(message);

            await _context.SaveChangesAsync();
        }
    }
}
