using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ETypeService
    {
        public ETypeService()
        {
            Lpks = new HashSet<Lpk>();
        }

        public int TypeServiceId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<Lpk> Lpks { get; set; }
    }
}
