using System;
using System.Collections.Generic;

#nullable disable

namespace EvitelLib2.Model
{
    public partial class Likointervence
    {
        public int IntervenceId { get; set; }
        public int? CallId { get; set; }
        public int? LikoincidentId { get; set; }
        public DateTime? DtStartIntervence { get; set; }
        public DateTime? DtEndIntervence { get; set; }
        public int? RegionId { get; set; }
        public string Note { get; set; }

        public virtual Call Call { get; set; }
        public virtual Likoincident Likoincident { get; set; }
        public virtual Region Region { get; set; }
    }
}
