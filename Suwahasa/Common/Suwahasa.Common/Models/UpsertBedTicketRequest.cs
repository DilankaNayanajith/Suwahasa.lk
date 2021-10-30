using System;

namespace Suwahasa.Common.Models
{
  public class UpsertBedTicketRequest
  {
    public long Id { get; set; }
    public long EnteredById { get; set; }
    public long BookingId { get; set; }
    public DateTime DateEntered { get; set; }
    public string Description { get; set; }
  }
}
