using System;
using System.Collections.Generic;

#nullable disable

namespace Test_Colleague.Models
{
    public partial class TGroup
    {
        public TGroup()
        {
            TGroupUsers = new HashSet<TGroupUser>();
            TMessages = new HashSet<TMessage>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<TGroupUser> TGroupUsers { get; set; }
        public virtual ICollection<TMessage> TMessages { get; set; }
    }
}
