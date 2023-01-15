using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class State
    {
        public int StateId { get; set; }
        public int StateType { get; set; }
        public int StateValue { get; set; }
        public string DescriptionType { get; set; }
        public string DescriptionValue { get; set; }
        public string Description { get; set; }
    }
}
