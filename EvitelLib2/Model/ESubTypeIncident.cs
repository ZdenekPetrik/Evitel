using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ESubTypeIncident
    {
        public ESubTypeIncident()
        {
            Likoincidents = new HashSet<Likoincident>();
        }

        public int SubTypeIncidentId { get; set; }
        public int? TypeIncidentId { get; set; }
        public string Text { get; set; }
        public string Kategorie { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ETypeIncident TypeIncident { get; set; }
        public virtual ICollection<Likoincident> Likoincidents { get; set; }
    }
}
