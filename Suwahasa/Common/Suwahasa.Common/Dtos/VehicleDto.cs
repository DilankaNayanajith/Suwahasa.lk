using System.Text.Json.Serialization;

namespace Suwahasa.Common.Dtos
{
    public class VehicleDto
    {
        public long Id { get; set; }
        public long? HospitalFk { get; set; }
        public string Category { get; set; }
        public long? DriverFk { get; set; }
        public bool? Available { get; set; }
        public string AvailableText
        {
            get
            {
                return Available.HasValue ? (Available.Value ? "Available" : "Unavailable") : "Unavailable"; 
            }
        }
        public string VehicleNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public EmployeeDto Driver { get; set; }
        public HospitalDto Hospital { get; set; }
    }
}
