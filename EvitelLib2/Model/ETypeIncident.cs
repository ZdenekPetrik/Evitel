using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ETypeIncident
    {
        public ETypeIncident()
        {
            ESubTypeIncidents = new HashSet<ESubTypeIncident>();
        }

        public int TypeIncidentId { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<ESubTypeIncident> ESubTypeIncidents { get; set; }
    }
}
