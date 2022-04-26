using System;
using System.Collections.Generic;

#nullable disable

namespace Test_Colleague.Models
{
    public partial class TMessage
    {
        public int MessageId { get; set; }
        public string MessageObject { get; set; }
        public string MessageContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }
        public bool? IsRead { get; set; }

        public virtual TGroup Group { get; set; }
    }
}
