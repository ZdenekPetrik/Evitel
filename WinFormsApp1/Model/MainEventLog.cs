using System;
using System.Collections.Generic;

#nullable disable

namespace WinFormsApp1.Model
{
    public partial class MainEventLog
    {
        public int Id { get; set; }
        public DateTime DtCreate { get; set; }
        public int LoginUserId { get; set; }
        public int EventCode { get; set; }
        public int EventSubCode { get; set; }
        public string Program { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
