using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Likoincident
    {
        public Likoincident()
        {
            Likointervences = new HashSet<Likointervence>();
        }

        public int LikoincidentId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public int? SubTypeIncidentEid { get; set; }
        public int? RegionId { get; set; }
        public DateTime? DtIncident { get; set; }
        public bool? NasledekSmrti { get; set; }
        public bool? Dokonane { get; set; }
        public bool? PokusPriprava { get; set; }
        public string Place { get; set; }
        public int? PocetPoskozenych { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ESubTypeIncident SubTypeIncidentE { get; set; }
        public virtual ICollection<Likointervence> Likointervences { get; set; }
    }
}
