using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class LpkclientCurrentStatus
    {
        public int LpksubClientCurentStatus { get; set; }
        public int? LpksubClientCurrentStatusEid { get; set; }
        public int? Lpkid { get; set; }

        public virtual Lpk Lpk { get; set; }
        public virtual ESubClientCurrentStatus LpksubClientCurrentStatusE { get; set; }
    }
}
