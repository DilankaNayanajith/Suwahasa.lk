using System;

namespace Suwahasa.Common.Dtos
{
  public class BedTicketDto
  {
    public long Id { get; set; }
    public long EnteredById { get; set; }
    public long BookingId { get; set; }
    public DateTime DateEntered { get; set; }
	public string DateEnteredText
	{
	  get
	  {
		return DateEntered.ToString("yyyy-MM-dd");
	  }
	}
	public string Description { get; set; }
    public virtual EmployeeDto EnteredBy { get; set; }
  }
}
