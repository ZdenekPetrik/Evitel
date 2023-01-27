using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class EContactService
    {
        public int ContactServiceId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }
    }
}
