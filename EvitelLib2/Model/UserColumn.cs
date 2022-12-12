using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class UserColumn
    {
        public int UserColumnId { get; set; }
        public int? ColumnIndex { get; set; }
        public int? DisplayIndex { get; set; }
        public bool? Visible { get; set; }
        public int? Width { get; set; }
        public int? LoginUserId { get; set; }
        public string Name { get; set; }
    }
}
