using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ETypeParty
    {
        public ETypeParty()
        {
            Likoparticipants = new HashSet<Likoparticipant>();
        }

        public int TypePartyId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<Likoparticipant> Likoparticipants { get; set; }
    }
}
