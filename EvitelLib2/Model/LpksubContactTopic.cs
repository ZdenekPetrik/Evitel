using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class LpksubContactTopic
    {
        public int LpksubContactTopicId { get; set; }
        public int? LpksubContactTopicEid { get; set; }
        public int? Lpkid { get; set; }

        public virtual Lpk Lpk { get; set; }
        public virtual ESubContactTopic LpksubContactTopicNavigation { get; set; }
    }
}
