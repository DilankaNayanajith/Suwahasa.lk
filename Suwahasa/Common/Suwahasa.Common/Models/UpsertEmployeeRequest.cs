using System.Text.Json.Serialization;

namespace Suwahasa.Common.Models
{
  public class UpsertEmployeeRequest
  {
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
	public bool? IsAuser { get; set; } = false;
  }
}
