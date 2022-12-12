using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class LoginAccessUser
    {
        public int LoginAccessUserId { get; set; }
        public int LoginUserId { get; set; }
        public int LoginAccessId { get; set; }

        public virtual LoginUser LoginUser { get; set; }
    }
}
