using System;
using System.Collections.Generic;

#nullable disable

namespace EvitelLib2.Model
{
    public partial class EDruhIntervence
    {
        public EDruhIntervence()
        {
            Likoparticipants = new HashSet<Likoparticipant>();
        }

        public int DruhIntervenceId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<Likoparticipant> Likoparticipants { get; set; }
    }
}
