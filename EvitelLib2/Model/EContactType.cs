using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class EContactType
    {
        public int ContactTypeId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }
    }
}
