using System.Text.Json.Serialization;

namespace Suwahasa.Common.Models
{
    public class UpsertPackageRequest
    {
        public long Id { get; set; }
        public long HospitalFk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
    }
}
