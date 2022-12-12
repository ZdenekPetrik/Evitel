using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class UserSetting
    {
        public int UserSettingId { get; set; }
        public int? LoginUserId { get; set; }
        public string Name { get; set; }
        public string SValue { get; set; }
        public int? IValue { get; set; }
        public DateTime? DValue { get; set; }
    }
}
