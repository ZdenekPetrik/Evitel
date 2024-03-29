﻿using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class WLpk
    {
        public int Lpkid { get; set; }
        public string Note { get; set; }
        public int ContactTypeEid { get; set; }
        public int TypeServiceEid { get; set; }
        public int? ClientFromEid { get; set; }
        public int? SexEid { get; set; }
        public int? AgeEid { get; set; }
        public int CallId { get; set; }
        public string Age { get; set; }
        public string TypeService { get; set; }
        public string ClientFrom { get; set; }
        public string Sex { get; set; }
        public DateTime? DtStartCall { get; set; }
        public DateTime? DtCall { get; set; }
        public string TmStartCall { get; set; }
        public string TmEndCall { get; set; }
        public string TmDuration { get; set; }
        public int? LoginUserId { get; set; }
        public string UsrFirstName { get; set; }
        public string UsrLastName { get; set; }
        public string Nick { get; set; }
        public string CallType { get; set; }
        public string ContactType { get; set; }
        public DateTime? DtEndCall { get; set; }
        public string ClientCurrentStatus { get; set; }
        public string ContactTopic { get; set; }
        public string EndOfSpeech { get; set; }
        public int? CallMonth { get; set; }
        public int? CallYear { get; set; }
    }
}
