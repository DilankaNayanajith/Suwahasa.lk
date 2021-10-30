using System;
using System.Collections.Generic;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class Payment
    {
        public long Id { get; set; }
        public long BookingFk { get; set; }
        public double? Amount { get; set; }
        public string Method { get; set; }

        public virtual Booking BookingFkNavigation { get; set; }
    }
}
