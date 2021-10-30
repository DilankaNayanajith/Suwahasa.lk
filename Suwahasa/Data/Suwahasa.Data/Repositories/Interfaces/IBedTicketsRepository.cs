using Suwahasa.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories.Interfaces
{
  public interface IBedTicketsRepository
  {
	Task<IList<BedTicket>> GetBedTicketsByBookingId(long bookingId);
	Task UpsertBedTicket(BedTicket bedTicket);
  }
}
