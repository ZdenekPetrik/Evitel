using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class EGrouping
    {
        public int GroupingId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public DateTime? DtDeleted { get; set; }
    }
}
