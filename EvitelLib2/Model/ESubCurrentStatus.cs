using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ESubCurrentStatus
    {
        public int SubCurrentStatusId { get; set; }
        public int? CurrentStatusId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual EEndOfSpeech CurrentStatus { get; set; }
    }
}
