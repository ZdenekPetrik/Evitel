using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Likoparticipant
    {
        public int LikoparticipantId { get; set; }
        public int? LikointervenceId { get; set; }
        public int? TypePartyEid { get; set; }
        public int? SexEid { get; set; }
        public int? Age { get; set; }
        public bool? IsDead { get; set; }
        public bool? IsInjury { get; set; }
        public bool? IsIntervence { get; set; }
        public bool? IsFirstIntervence { get; set; }
        public int? DruhIntervenceEid { get; set; }
        public int? InterventId { get; set; }
        public int? InterventId2 { get; set; }
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

        public virtual EDruhIntervence DruhIntervenceE { get; set; }
        public virtual Intervent Intervent { get; set; }
        public virtual Intervent InterventId2Navigation { get; set; }
        public virtual Likointervence Likointervence { get; set; }
        public virtual ESex SexE { get; set; }
        public virtual ETypeParty TypePartyE { get; set; }
    }
}
