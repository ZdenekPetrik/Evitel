using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Call
    {
        public Call()
        {
            Likointervences = new HashSet<Likointervence>();
            Lpks = new HashSet<Lpk>();
        }

        public int CallId { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtEndCall { get; set; }
        public int? LoginUserId { get; set; }
        public int? CallType { get; set; }

        public virtual LoginUser LoginUser { get; set; }
        public virtual ICollection<Likointervence> Likointervences { get; set; }
        public virtual ICollection<Lpk> Lpks { get; set; }
    }
}
