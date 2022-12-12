using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Likoincident
    {
        public Likoincident()
        {
            InverseLikoincidentIdMasterNavigation = new HashSet<Likoincident>();
            Likointervences = new HashSet<Likointervence>();
            Likoparticipants = new HashSet<Likoparticipant>();
        }

        public int LikoincidentId { get; set; }
        public int? LikoincidentIdMaster { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public int? SubTypeIntervenceEid { get; set; }
        public int? RegionId { get; set; }
        public DateTime? DtIncident { get; set; }
        public bool? NasledekSmrti { get; set; }
        public bool? Dokonane { get; set; }
        public bool? PokusPriprava { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual Likoincident LikoincidentIdMasterNavigation { get; set; }
        public virtual ESubTypeIntervence SubTypeIntervenceE { get; set; }
        public virtual ICollection<Likoincident> InverseLikoincidentIdMasterNavigation { get; set; }
        public virtual ICollection<Likointervence> Likointervences { get; set; }
        public virtual ICollection<Likoparticipant> Likoparticipants { get; set; }
    }
}
