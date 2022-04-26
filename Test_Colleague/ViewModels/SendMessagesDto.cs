using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Colleague.ViewModels
{
    public class SendMessagesDto
    {
        public string MessageObject { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public SendMessagesDto()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
