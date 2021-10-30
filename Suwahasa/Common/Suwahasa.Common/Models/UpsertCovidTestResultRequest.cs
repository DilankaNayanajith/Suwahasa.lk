using System;

namespace Suwahasa.Common.Models
{
  public class UpsertCovidTestResultRequest
  {
    public long Id { get; set; }
    public long BookingId { get; set; }
    public string Type { get; set; }
    public DateTime DateTested { get; set; }
    public string Result { get; set; }
  }
}
