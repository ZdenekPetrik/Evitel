using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikoall
    {
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtCall { get; set; }
        public string TmCall { get; set; }
        public string Volajici { get; set; }
        public string VolajiciKraj { get; set; }
        public int? CallId { get; set; }
        public DateTime? DtIncident { get; set; }
        public int? UdalostMonth { get; set; }
        public int? UdalostYear { get; set; }
        public DateTime? DtUdalost { get; set; }
        public string TmUdalost { get; set; }
        public string UdalostRegion { get; set; }
        public string UdalostMisto { get; set; }
        public string UdalostNote { get; set; }
        public string DruhUdalosti { get; set; }
        public string KategorieUdalosti { get; set; }
        public int? PocetPoskozenych { get; set; }
        public int? UdalostId { get; set; }
        public int IntervenceId { get; set; }
        public DateTime? DtStartIntervence { get; set; }
        public DateTime? DtIntervStart { get; set; }
        public string TmIntervStart { get; set; }
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
        public string TypePartyText { get; set; }
        public string SexText { get; set; }
        public int Age { get; set; }
        public bool IsDead { get; set; }
        public bool IsInjury { get; set; }
        public bool IsIntervence { get; set; }
        public bool IsFirstIntervence { get; set; }
        public string DruhIntervence { get; set; }
        public string InterventName { get; set; }
        public string RegionName { get; set; }
        public int? InterventId2 { get; set; }
        public string Intervent2Name { get; set; }
        public bool IsAgreement { get; set; }
        public bool IsAgreementBkb { get; set; }
        public bool IsContact { get; set; }
        public bool IsPolicement { get; set; }
        public bool IsPolicementClosePerson { get; set; }
        public bool IsSenior { get; set; }
        public bool IsChildJuvenile { get; set; }
        public bool IsHandyCappedMedical { get; set; }
        public bool IsHandyCappedMentally { get; set; }
        public bool IsMemberMinorityGroup { get; set; }
        public string Organization { get; set; }
        public string Note { get; set; }
        public int ParticipantId { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstName { get; set; }
        public int? LoginUserId { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
    }
}
