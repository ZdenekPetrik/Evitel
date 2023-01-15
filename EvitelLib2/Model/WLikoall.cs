using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikoall
    {
        public int LikoparticipantId { get; set; }
        public int? LikointervenceId { get; set; }
        public int? CallId { get; set; }
        public int? LikoincidentId { get; set; }
        public int? TypePartyEid { get; set; }
        public string TypePartyText { get; set; }
        public int? SexEid { get; set; }
        public string SexText { get; set; }
        public int? Age { get; set; }
        public bool? IsDead { get; set; }
        public bool? IsInjury { get; set; }
        public bool? IsIntervence { get; set; }
        public bool? IsFirstIntervence { get; set; }
        public int? DruhIntervenceEid { get; set; }
        public string DruhIntervenceText { get; set; }
        public int? InterventId { get; set; }
        public string InterventName { get; set; }
        public string RegionName { get; set; }
        public int? InterventId2 { get; set; }
        public string Intervent2Name { get; set; }
        public bool? IsAgreement { get; set; }
        public bool? IsAgreementBkb { get; set; }
        public bool? IsContact { get; set; }
        public bool? IsPolicement { get; set; }
        public bool? IsPolicementClosePerson { get; set; }
        public bool? IsSenior { get; set; }
        public bool? IsChildJuvenile { get; set; }
        public bool? IsHandyCappedMedical { get; set; }
        public bool? IsHandyCappedMentally { get; set; }
        public bool? IsMemberMinorityGroup { get; set; }
        public string Organization { get; set; }
        public string Note { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtStartIntervence { get; set; }
        public DateTime? DtEndIntervence { get; set; }
        public DateTime? DtIncident { get; set; }
        public string IntervenceNote { get; set; }
        public int? ObetemPoskozenym { get; set; }
        public int? PozustalymBlizkym { get; set; }
        public int? Ostatnim { get; set; }
        public int? IntInterventId { get; set; }
        public string IntInterventName { get; set; }
        public string IntRegion { get; set; }
        public int? Poradi { get; set; }
        public int? LoginUserId { get; set; }
        public int? IncRegionId { get; set; }
        public string IncRegion { get; set; }
        public int? SubTypeIncidentEid { get; set; }
        public string IncIncident { get; set; }
        public string IncKategorie { get; set; }
        public string IncNote { get; set; }
        public bool? NasledekSmrti { get; set; }
        public bool? Dokonane { get; set; }
        public bool? PokusPriprava { get; set; }
        public string IncMisto { get; set; }
        public int? PocetPoskozenych { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
