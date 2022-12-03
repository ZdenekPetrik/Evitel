using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp1.Model
{
    public partial class MainSetting
    {
        public int MainSettingId { get; set; }
        public string Name { get; set; }
        public string SValue { get; set; }
        public int? IValue { get; set; }
        public DateTime? DValue { get; set; }
    }
}
