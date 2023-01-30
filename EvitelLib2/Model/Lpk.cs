using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Lpk
    {
        public Lpk()
        {
            LpkclientCurrentStatuses = new HashSet<LpkclientCurrentStatus>();
            LpksubContactTopics = new HashSet<LpksubContactTopic>();
            LpksubEndOfSpeeches = new HashSet<LpksubEndOfSpeech>();
        }

        public int Lpkid { get; set; }
        public string Note { get; set; }
        public int ContactTypeEid { get; set; }
        public int TypeServiceEid { get; set; }
        public int ClientFromEid { get; set; }
        public int SexEid { get; set; }
        public int AgeEid { get; set; }
        public string Nick { get; set; }
        public int CallId { get; set; }

        public virtual EAge AgeE { get; set; }
        public virtual Call Call { get; set; }
        public virtual EClientFrom ClientFromE { get; set; }
        public virtual EContactType ContactTypeE { get; set; }
        public virtual ESex SexE { get; set; }
        public virtual ETypeService TypeServiceE { get; set; }
        public virtual ICollection<LpkclientCurrentStatus> LpkclientCurrentStatuses { get; set; }
        public virtual ICollection<LpksubContactTopic> LpksubContactTopics { get; set; }
        public virtual ICollection<LpksubEndOfSpeech> LpksubEndOfSpeeches { get; set; }
    }
}
