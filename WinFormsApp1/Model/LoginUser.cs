using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp1.Model
{
    public partial class LoginUser
    {
        public LoginUser()
        {
            LoginAccessUsers = new HashSet<LoginAccessUser>();
        }

        public int LoginUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<LoginAccessUser> LoginAccessUsers { get; set; }
    }
}
