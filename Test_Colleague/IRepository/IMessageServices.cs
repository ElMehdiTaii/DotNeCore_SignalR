using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Colleague.Models;
using Test_Colleague.ViewModels;

namespace Test_Colleague.IRepository
{
    public interface IMessageServices
    {
        Task<IEnumerable<TMessage>> GetMessagesAsync();
        Task<int> GetNotificationAsync(int UserId);
        Task SendMessagesAsync(SendMessagesDto model);
    }
}
