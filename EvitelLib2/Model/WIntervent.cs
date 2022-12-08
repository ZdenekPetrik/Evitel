using System;
using System.Collections.Generic;

#nullable disable

namespace EvitelLib2.Model
{
    public partial class WIntervent
    {
        public int InterventId { get; set; }
        public string Rank { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string RegionName { get; set; }
        public int? RegionOrder { get; set; }
        public string RegionShortName { get; set; }
        public string CmbName { get; set; }
    }
}
