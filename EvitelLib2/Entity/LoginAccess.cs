using System.ComponentModel.DataAnnotations;

namespace EvitelLib2
{
    public class LoginAccess
    {
        [Key]
        public int LoginAccessId { get; set; }
        [MaxLength(50)]
        public string AccessName { get; set; }
    }
}
