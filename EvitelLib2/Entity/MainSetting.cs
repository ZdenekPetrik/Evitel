using System;
using System.ComponentModel.DataAnnotations;

namespace EvitelLib2
{
    public class MainSetting
    {
        [Key]
        public int MainSettingId { get; set; }
        public string Name { get; set; }
        public string sValue { get; set; }
        public int? iValue { get; set; }
        public DateTime? dValue { get; set; }
    }
}
