using System;
using System.Collections.Generic;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class CovidTestResult
    {
        public long Id { get; set; }
        public long BookingFk { get; set; }
        public string Type { get; set; }
        public DateTime DateTested { get; set; }
        public string Result { get; set; }

        public virtual Booking BookingFkNavigation { get; set; }
    }
}
