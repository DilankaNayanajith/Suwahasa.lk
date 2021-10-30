using System.Text.Json.Serialization;

namespace Suwahasa.Common.Models
{
    public class UpsertVehicleRequest
    {
        public long Id { get; set; }
        public long? HospitalFk { get; set; }
        public string Category { get; set; }
        public long? DriverFk { get; set; }
        public bool? Available { get; set; }
        public string VehicleNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
    }
}
