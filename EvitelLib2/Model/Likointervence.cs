using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Likointervence
    {
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

        public virtual Call Call { get; set; }
        public virtual Likoincident LikointervenceNavigation { get; set; }
    }
}
