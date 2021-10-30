namespace Suwahasa.Common.Models
{
  public class AuthUser
  {
	public long Id { get; set; }
	public long? EmployeeId { get; set; }
	public string City { get; set; }
	public string Name { get; set; }
	public string Role { get;set; }
	public long? HospitalId { get; set; }
  }
}
