using System;
using System.Collections.Generic;

#nullable disable

namespace EvitelLib2.Model
{
    public partial class ETypeIntervence
    {
        public ETypeIntervence()
        {
            ESubTypeIntervences = new HashSet<ESubTypeIntervence>();
        }

        public int TypeIntervenceId { get; set; }
        public string Text { get; set; }
        public string ShortText { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<ESubTypeIntervence> ESubTypeIntervences { get; set; }
    }
}
