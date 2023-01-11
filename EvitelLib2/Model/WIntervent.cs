using System;
using System.Collections.Generic;

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
        public string Phone { get; set; }
        public string MobilPhone { get; set; }
        public string PrivatePhone { get; set; }
        public string Email { get; set; }
        public DateTime DtCreate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RegionId { get; set; }
        public string InterventShortName { get; set; }
    }
}
