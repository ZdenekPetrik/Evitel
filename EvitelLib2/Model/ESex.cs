using System;
using System.Collections.Generic;

#nullable disable

namespace EvitelLib2.Model
{
    public partial class ESex
    {
        public ESex()
        {
            Likoparticipants = new HashSet<Likoparticipant>();
        }

        public int SexId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDelete { get; set; }

        public virtual ICollection<Likoparticipant> Likoparticipants { get; set; }
    }
}
