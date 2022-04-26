using System;
using System.Collections.Generic;

#nullable disable

namespace Test_Colleague.Models
{
    public partial class TGroupUser
    {
        public int GroupUserId { get; set; }
        public int? GroupId { get; set; }
        public int? UserId { get; set; }

        public virtual TGroup Group { get; set; }
    }
}
