using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikoincident
    {
        public int LikoincidentId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public int? SubTypeIncidentEid { get; set; }
        public int? RegionId { get; set; }
        public DateTime? DtIncident { get; set; }
        public bool? NasledekSmrti { get; set; }
        public bool? Dokonane { get; set; }
        public bool? PokusPriprava { get; set; }
        public string Place { get; set; }
        public int? PocetPoskozenych { get; set; }
        public int? IntervenceCount { get; set; }
        public string RegionName { get; set; }
        public string IncidentName { get; set; }
        public string IncidentCategory { get; set; }
        public DateTime? DtIncidentDate { get; set; }
        public string TmIncident { get; set; }
        public int? FirstLikoIntervenceId { get; set; }
    }
}
