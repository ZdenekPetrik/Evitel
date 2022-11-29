using System;
using System.ComponentModel.DataAnnotations;

namespace EvitelLib2
{
   
    public class wMainEventLog
    {
        public int Id { get; set; }
        public DateTime dtCreate { get; set; }
        public int LoginUserId { get; set; }
        public eEventCode eventCode { get; set; }
        public eEventSubCode eventSubCode { get; set; }
        public string Program { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CodeText { get; set; }
        public string SubCodeText { get; set; }
    }
}
