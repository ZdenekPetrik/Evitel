using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ECurrentStatus
    {
        public int CurrentStatusId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }
    }
}
