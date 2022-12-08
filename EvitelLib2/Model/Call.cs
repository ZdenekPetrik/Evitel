using System;
using System.Collections.Generic;

#nullable disable

namespace EvitelLib2.Model
{
    public partial class Call
    {
        public Call()
        {
            Likointervences = new HashSet<Likointervence>();
        }

        public int CallId { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtEndCall { get; set; }
        public int? LoginUserId { get; set; }

        public virtual LoginUser LoginUser { get; set; }
        public virtual ICollection<Likointervence> Likointervences { get; set; }
    }
}
