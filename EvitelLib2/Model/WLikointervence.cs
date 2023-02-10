using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikointervence
    {
        public DateTime? DtEndIntervence { get; set; }
        public DateTime? DtIntervEnd { get; set; }
        public string TmIntervEnd { get; set; }
        public string TmIntervDuration { get; set; }
        public string IntrvNote { get; set; }
        public int? ObetemPoskozenym { get; set; }
        public int? PozustalymBlizkym { get; set; }
        public int? Ostatnim { get; set; }
        public int? IntervPoradi { get; set; }
        public int? IntrvId { get; set; }
        public int LikointervenceId { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtCall { get; set; }
        public string TmCall { get; set; }
        public string Volajici { get; set; }
        public string VolajiciKraj { get; set; }
        public int? CallId { get; set; }
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
        public int? LikoincidentId { get; set; }
        public DateTime? DtStartIntervence { get; set; }
        public DateTime? DtIntervStart { get; set; }
        public string TmIntervStart { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstName { get; set; }
        public int? LoginUserId { get; set; }
    }
}
