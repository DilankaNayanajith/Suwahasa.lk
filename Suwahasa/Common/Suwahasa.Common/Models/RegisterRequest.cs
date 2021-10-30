using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Common.Models
{
    public class RegisterRequest
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public int? Age { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Nic { get; set; }
        public string ContactNumber { get; set; }
        public string BloodGroup { get; set; }
        public string ParentOrGuardian { get; set; }
        public string EmergencyContact { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public string Type { get; set; }
    }
}
