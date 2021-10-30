using System;
using System.Collections.Generic;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            BedTickets = new HashSet<BedTicket>();
            CovidTestResults = new HashSet<CovidTestResult>();
            Payments = new HashSet<Payment>();
        }

        public long Id { get; set; }
        public long UserFk { get; set; }
        public long HospitalFk { get; set; }
        public long? PackageFk { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool TransportRequested { get; set; }
        public DateTime? TransportDate { get; set; }
        public long? VehicleFk { get; set; }
        public DateTime? DateAdmitted { get; set; }
        public DateTime? DateDischarged { get; set; }
        public string PaymentStatus { get; set; }
        public bool TransportApproved { get; set; }
        public DateTime? ReservationDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Hospital HospitalFkNavigation { get; set; }
        public virtual Package PackageFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
        public virtual Vehicle VehicleFkNavigation { get; set; }
        public virtual ICollection<BedTicket> BedTickets { get; set; }
        public virtual ICollection<CovidTestResult> CovidTestResults { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
