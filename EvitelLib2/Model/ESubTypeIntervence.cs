using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ESubTypeIntervence
    {
        public ESubTypeIntervence()
        {
            Likoincidents = new HashSet<Likoincident>();
        }

        public int SubTypeIntervenceId { get; set; }
        public int? TypeIntervenceId { get; set; }
        public string Text { get; set; }
        public string Kategorie { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ETypeIntervence TypeIntervence { get; set; }
        public virtual ICollection<Likoincident> Likoincidents { get; set; }
    }
}
