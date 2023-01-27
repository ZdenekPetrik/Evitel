using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class EContactTopic
    {
        public EContactTopic()
        {
            ESubContactTopics = new HashSet<ESubContactTopic>();
        }

        public int ContactTopicId { get; set; }
        public string Text { get; set; }
        public DateTime? DtDeleted { get; set; }

        public virtual ICollection<ESubContactTopic> ESubContactTopics { get; set; }
    }
}
