using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikoincident
    {
        public DateTime? DtIncident { get; set; }
        public DateTime? DtUdalost { get; set; }
        public string TmUdalost { get; set; }
        public string UdalostRegion { get; set; }
        public string UdalostMisto { get; set; }
        public string UdalostNote { get; set; }
        public string DruhUdalosti { get; set; }
        public string KategorieUdalosti { get; set; }
        public bool? NasledekSmrti { get; set; }
        public bool? Dokonane { get; set; }
        public bool? PokusPriprava { get; set; }
        public int? PocetPoskozenych { get; set; }
        public int LikoincidentId { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtCall { get; set; }
        public string TmCall { get; set; }
        public string Volajici { get; set; }
        public string VolajiciKraj { get; set; }
        public int? CallId { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstName { get; set; }
        public int? LoginUserId { get; set; }
    }
}
