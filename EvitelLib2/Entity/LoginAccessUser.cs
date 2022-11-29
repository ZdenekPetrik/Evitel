using System.ComponentModel.DataAnnotations;

namespace EvitelLib2
{
    public class LoginAccessUser
    {
        [Key]
        public int LoginAccessUserId { get; set; }
        public int LoginUserId { get; set; }
        public int LoginAccessId { get; set; }

    }
}
