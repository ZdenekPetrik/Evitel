using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ESubEndOfSpeech
    {
        public ESubEndOfSpeech()
        {
            LpksubEndOfSpeeches = new HashSet<LpksubEndOfSpeech>();
        }

        public int SubEndOfSpeechId { get; set; }
        public int? EndOfSpeechId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual EEndOfSpeech EndOfSpeech { get; set; }
        public virtual ICollection<LpksubEndOfSpeech> LpksubEndOfSpeeches { get; set; }
    }
}
