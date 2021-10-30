using System;
using System.Collections.Generic;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class BedTicket
    {
        public long Id { get; set; }
        public long EnteredByFk { get; set; }
        public long BookingFk { get; set; }
        public DateTime DateEntered { get; set; }
        public string Description { get; set; }

        public virtual Booking BookingFkNavigation { get; set; }
        public virtual Employee EnteredByFkNavigation { get; set; }
    }
}
