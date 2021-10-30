namespace Suwahasa.Common.Models
{
  public class UpsertBookingRequest
  {
	public long UserId { get; set; }
	public long HospitalId { get; set; }
	public long PackageId { get; set; }
	public string ReservationDate { get; set; }
	public bool TransportRequested { get; set; }
	public string PaymentStatus { get; set; }
  }
}
