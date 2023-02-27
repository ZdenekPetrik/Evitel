using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLikoparticipant
    {
        public int LikoparticipantId { get; set; }
        public int LikointervenceId { get; set; }
        public int TypePartyEid { get; set; }
        public int SexEid { get; set; }
        public int Age { get; set; }
        public bool IsDead { get; set; }
        public bool IsInjury { get; set; }
        public bool IsIntervence { get; set; }
        public bool IsFirstIntervence { get; set; }
        public int? DruhIntervenceEid { get; set; }
        public int? InterventId { get; set; }
        public bool IsAgreement { get; set; }
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
        public int? InterventId2 { get; set; }
        public bool IsAgreementBkb { get; set; }
        public DateTime? DtStartIntervence { get; set; }
        public DateTime? DtEndIntervence { get; set; }
        public string IntervenceNote { get; set; }
        public int? ObetemPoskozenym { get; set; }
        public int? PozustalymBlizkym { get; set; }
        public int? Ostatnim { get; set; }
        public int? IntervPoradi { get; set; }
        public DateTime? DtStartCall { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string SexText { get; set; }
        public string DruhIntervenceText { get; set; }
        public string TypePartyText { get; set; }
        public int MainInterventId { get; set; }
        public string UdalostRegion { get; set; }
        public string InterventName { get; set; }
        public string InterventName2 { get; set; }
        public int? Poradi { get; set; }
        public DateTime? DtIntervStart { get; set; }
        public string TmIntervStart { get; set; }
    }
}
