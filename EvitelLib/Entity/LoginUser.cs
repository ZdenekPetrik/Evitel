using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Entity
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
