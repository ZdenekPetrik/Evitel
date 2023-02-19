using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class DimDateTime
    {
        public DateTime Date { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public DateTime? FirstOfMonth { get; set; }
        public string MonthName { get; set; }
        public int? Week { get; set; }
        public int? Isoweek { get; set; }
        public int? DayOfWeek { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }
        public DateTime? FirstOfYear { get; set; }
        public string Style112 { get; set; }
        public string Style101 { get; set; }
        public int HalfOfYear { get; set; }
    }
}
