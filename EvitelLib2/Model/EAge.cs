using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class EAge
    {
        public EAge()
        {
            Lpks = new HashSet<Lpk>();
        }

        public int AgeId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<Lpk> Lpks { get; set; }
    }
}
