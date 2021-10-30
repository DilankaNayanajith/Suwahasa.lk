using Microsoft.EntityFrameworkCore;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories
{
  public class BedTicketsRepository: IBedTicketsRepository
  {
	private readonly Entities.DatabaseContext databaseContext;

	public BedTicketsRepository()
	{
	  databaseContext = new Entities.DatabaseContext();
	}

	public async Task<IList<BedTicket>> GetBedTicketsByBookingId(long bookingId)
	{
	  var tickets = await databaseContext.BedTickets
							.Where(b => b.BookingFk == bookingId)
							.Include(b => b.EnteredByFkNavigation)
							.OrderByDescending(b => b.DateEntered)
							.ToListAsync();
	  return tickets;
	}

	public async Task UpsertBedTicket(BedTicket bedTicket)
	{
	  if (bedTicket.Id == 0)
	  {
		  await databaseContext.BedTickets.AddAsync(bedTicket);
		  databaseContext.Entry(bedTicket).State = EntityState.Added;
	  }
	  else
	  {
		databaseContext.BedTickets.Update(bedTicket);
		databaseContext.Entry(bedTicket).State = EntityState.Modified;
	  }
	  await databaseContext.SaveChangesAsync();
	}
  }
}
