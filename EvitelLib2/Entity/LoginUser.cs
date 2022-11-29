using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvitelLib2
{
    public class LoginUser
    {
        //Table properties
        [Key]
        public int LoginUserId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string LoginName { get; set; }
        [MaxLength(50)]
        public string LoginPassword { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<LoginAccessUser> Access { get; set; }
    }
}
