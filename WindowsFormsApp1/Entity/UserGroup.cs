using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Entity
{
    public class LoginAccess
    {
        [Key]
        public int userGrou Id { get; set; }
        [MaxLength(50)]
        public string AccessName { get; set; }
    }
}
