namespace Suwahasa.Common.Models
{
    public class UpsertHospitalRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int? CovidPatientCount { get; set; }
        public int? DischargedCovidPatientCount { get; set; }
        public int? IcuBedCount { get; set; }
        public double? AvailableOxygen { get; set; }
        public string WardDescription { get; set; }
        public string SanitaryDetails { get; set; }
        public string MealsDetails { get; set; }
        public int? ActiveDoctors { get; set; }
        public int? ActiveNurses { get; set; }
        public int? AvailableAmbulances { get; set; }
        public double? CostPerPatient { get; set; }
    }
}
