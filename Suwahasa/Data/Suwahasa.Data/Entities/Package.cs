using System;
using System.Collections.Generic;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class Package
    {
        public Package()
        {
            Bookings = new HashSet<Booking>();
        }

        public long Id { get; set; }
        public long HospitalFk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }

        public virtual Hospital HospitalFkNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
