using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class LpksubEndOfSpeech
    {
        public int LpksubEndOfSpeechId { get; set; }
        public int? LpksubEndOfSpeechEid { get; set; }
        public int? Lpkid { get; set; }

        public virtual Lpk Lpk { get; set; }
        public virtual ESubEndOfSpeech LpksubEndOfSpeechE { get; set; }
    }
}
