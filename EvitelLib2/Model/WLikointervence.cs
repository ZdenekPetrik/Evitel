using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikointervence
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
        public DateTime? DtStartCall { get; set; }
        public int? LoginUserId { get; set; }
        public string UsrFirstName { get; set; }
        public string UsrLastName { get; set; }
        public int? InterventId { get; set; }
        public string InterventShortName { get; set; }
        public string RegionName { get; set; }
        public DateTime? DateStartIntervence { get; set; }
        public string TimeStartIntervence { get; set; }
        public int? Poradi { get; set; }
    }
}
