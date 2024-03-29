﻿using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class LoginUser
    {
        public LoginUser()
        {
            Calls = new HashSet<Call>();
            LoginAccessUsers = new HashSet<LoginAccessUser>();
        }

        public int LoginUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Call> Calls { get; set; }
        public virtual ICollection<LoginAccessUser> LoginAccessUsers { get; set; }
    }
}
