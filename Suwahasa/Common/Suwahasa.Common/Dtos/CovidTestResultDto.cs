using System;

namespace Suwahasa.Common.Dtos
{
  public class CovidTestResultDto
  {
	public long Id { get; set; }
	public long BookingId { get; set; }
	public string Type { get; set; }
	public DateTime DateTested { get; set; }
	public string DateTestedText
	{
	  get
	  {
		return DateTested.ToString("yyyy-MM-dd");
	  }
	}
	public string Result { get; set; }
  }
}
