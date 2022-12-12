using System;
using System.Collections.Generic;

namespace EvitelLib2.Model
{
    public partial class Intervent
    {
        public Intervent()
        {
            Likoparticipants = new HashSet<Likoparticipant>();
        }

        public int InterventId { get; set; }
        public string Rank { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string MobilPhone { get; set; }
        public string PrivatePhone { get; set; }
        public string Email { get; set; }
        public DateTime? DtDeleted { get; set; }
        public string Note { get; set; }
        public int? RegionId { get; set; }
        public DateTime DtCreate { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Likoparticipant> Likoparticipants { get; set; }
    }
}
