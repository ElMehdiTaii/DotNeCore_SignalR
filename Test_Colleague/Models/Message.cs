using System;
using System.Collections.Generic;

#nullable disable

namespace Test_Colleague.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime? SendingDate { get; set; }
        public TimeSpan? SendingTime { get; set; }
        public bool? IsRead { get; set; }

        public virtual User Receiver { get; set; }
        public virtual User Sender { get; set; }
    }
}
