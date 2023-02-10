using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikocall
    {
        public int CallId { get; set; }
        public int LikointervenceId { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtCall { get; set; }
        public string TmStartCall { get; set; }
        public int? LoginUserId { get; set; }
        public string UsrFirstName { get; set; }
        public string UsrLastName { get; set; }
        public int? InterventId { get; set; }
        public string InterventShortName { get; set; }
        public string RegionName { get; set; }
        public string CallType { get; set; }
    }
}
