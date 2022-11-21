using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Entity
{
    public class MainSetting
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public string sValue { get; set; }
        public int? iValue { get; set; }
        public DateTime? dValue { get; set; }
    }
}
