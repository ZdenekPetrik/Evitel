using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikocall
    {
        public int CallId { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtEndCall { get; set; }
        public int? LoginUserId { get; set; }
        public string UsrFirstName { get; set; }
        public string UsrLastName { get; set; }
    }
}
