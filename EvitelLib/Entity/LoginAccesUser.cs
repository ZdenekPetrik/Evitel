using System.ComponentModel.DataAnnotations;

namespace EvitelLib.Entity
{
    public class LoginAccessUser
    {
        [Key]
        public int LoginAccessUserId { get; set; }
        public int LoginUserId { get; set; }
        public int LoginAccessId { get; set; }

    }
}
