using Suwahasa.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Suwahasa.Common.Models;

namespace Suwahasa.Services.Interfaces
{
  public interface IBedTicketsServices
  {
	Task<IList<BedTicketDto>> GetBedTicketsByBookingId(long bookingId);
	Task UpsertBedTicket(UpsertBedTicketRequest bedTicket);
  }
}
