using System;
using System.Collections.Generic;

#nullable disable

namespace Suwahasa.Data.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            BedTickets = new HashSet<BedTicket>();
            Users = new HashSet<User>();
            Vehicles = new HashSet<Vehicle>();
        }

        public long Id { get; set; }
        public long? HospitalFk { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Nic { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string Role { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Specialization { get; set; }
        public bool Active { get; set; }
        public bool? IsAuser { get; set; }

        public virtual Hospital HospitalFkNavigation { get; set; }
        public virtual ICollection<BedTicket> BedTickets { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
