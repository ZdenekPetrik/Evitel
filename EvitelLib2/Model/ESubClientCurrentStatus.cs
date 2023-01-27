using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ESubClientCurrentStatus
    {
        public int SubClientCurrentStatusId { get; set; }
        public int? ClientCurrentStatusId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual EEndOfSpeech ClientCurrentStatus { get; set; }
    }
}
