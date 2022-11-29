using System;
using System.ComponentModel.DataAnnotations;

namespace EvitelLib2
{
    public class MainEventLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime dtCreate { get; set; }
        public int LoginUserId { get; set; }
        public eEventCode eventCode { get; set; }
        public eEventSubCode eventSubCode { get; set; }
        [MaxLength(50)]
        public string Program { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }


    public enum eEventCode
    {
        e1Program = 101,
        e1Login = 102,
        e1Message = 103,
    };
    public enum eEventSubCode
    {
        e2Start = 1,
        e2Stop = 2,
        e2BadLogin = 3,
        e2ChangePassword = 4,

        e2Error = 11,
        e2Warning = 12,
        e2Info = 13,
        e2Debug = 13,

        e2Create = 21,
        e2Modify = 22,
        e2Remove = 23
    };
}
