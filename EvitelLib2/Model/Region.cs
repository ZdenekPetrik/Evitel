using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Region
    {
        public Region()
        {
            Intervents = new HashSet<Intervent>();
            Likointervences = new HashSet<Likointervence>();
        }

        public int RegionId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Name2 { get; set; }
        public int? RegionOrder { get; set; }

        public virtual ICollection<Intervent> Intervents { get; set; }
        public virtual ICollection<Likointervence> Likointervences { get; set; }
    }
}
