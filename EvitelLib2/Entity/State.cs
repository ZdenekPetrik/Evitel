using System.ComponentModel.DataAnnotations;

namespace EvitelLib2
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public int StateType { get; set; }
        public int StateValue { get; set; }
        [MaxLength(50)]
        public string DescriptionType { get; set; }
        [MaxLength(50)]
        public string DescriptionValue { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
