using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class ESubContactTopic
    {
        public int SubContactTopicId { get; set; }
        public int? ContactTopicId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual EContactTopic ContactTopic { get; set; }
        public virtual LpksubContactTopic LpksubContactTopic { get; set; }
    }
}
