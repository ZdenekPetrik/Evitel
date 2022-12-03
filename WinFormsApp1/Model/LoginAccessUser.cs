using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp1.Model
{
    public partial class LoginAccessUser
    {
        public int LoginAccessUserId { get; set; }
        public int LoginUserId { get; set; }
        public int LoginAccessId { get; set; }

        public virtual LoginUser LoginUser { get; set; }
    }
}
