using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class EEndOfSpeech
    {
        public EEndOfSpeech()
        {
            ESubClientCurrentStatuses = new HashSet<ESubClientCurrentStatus>();
            ESubEndOfSpeeches = new HashSet<ESubEndOfSpeech>();
        }

        public int EndOfSpeechId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<ESubClientCurrentStatus> ESubClientCurrentStatuses { get; set; }
        public virtual ICollection<ESubEndOfSpeech> ESubEndOfSpeeches { get; set; }
    }
}
