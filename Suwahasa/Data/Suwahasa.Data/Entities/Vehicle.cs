using System;
using System.Collections.Generic;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Bookings = new HashSet<Booking>();
        }

        public long Id { get; set; }
        public long? HospitalFk { get; set; }
        public string Category { get; set; }
        public long? DriverFk { get; set; }
        public bool? Available { get; set; }
        public string VehicleNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }

        public virtual Employee DriverFkNavigation { get; set; }
        public virtual Hospital HospitalFkNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
