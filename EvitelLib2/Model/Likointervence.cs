using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Likointervence
    {
        public Likointervence()
        {
            Likoparticipants = new HashSet<Likoparticipant>();
        }

        public int LikointervenceId { get; set; }
        public int? CallId { get; set; }
        public int? LikoincidentId { get; set; }
        public DateTime? DtStartIntervence { get; set; }
        public DateTime? DtEndIntervence { get; set; }
        public string Note { get; set; }
        public int? ObetemPoskozenym { get; set; }
        public int? PozustalymBlizkym { get; set; }
        public int? Ostatnim { get; set; }
        public int? LikointervenceIdmaster { get; set; }
        public int? InterventId { get; set; }
        public int? Poradi { get; set; }

        public virtual Call Call { get; set; }
        public virtual Intervent Intervent { get; set; }
        public virtual Likoincident Likoincident { get; set; }
        public virtual ICollection<Likoparticipant> Likoparticipants { get; set; }
    }
}
