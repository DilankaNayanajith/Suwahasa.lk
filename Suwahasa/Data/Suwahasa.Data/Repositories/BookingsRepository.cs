using Microsoft.EntityFrameworkCore;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories
{
  public class BookingsRepository: IBookingsRepository
  {
	/// <summary>
	/// The database context
	/// </summary>
	private readonly Entities.DatabaseContext databaseContext;

	/// <summary>
	/// Initializes a new instance of the <see cref="BookingsRepository"/> class.
	/// </summary>
	public BookingsRepository()
	{
	  databaseContext = new Entities.DatabaseContext();
	}

	public async Task<Booking> GetBookingById(long bookingId)
	{
	  return await databaseContext.Bookings
					  .Where(b => b.Id == bookingId)
					  .Include(b => b.HospitalFkNavigation)
					  .Include(b => b.PackageFkNavigation)
					  .Include(b => b.VehicleFkNavigation)
					  .Include(b => b.BedTickets.OrderByDescending(bt => bt.DateEntered)).ThenInclude(b => b.EnteredByFkNavigation)
					  .Include(b => b.CovidTestResults.OrderByDescending(ctr => ctr.DateTested))
					  .FirstOrDefaultAsync();
	}

	public async Task<IList<Booking>> GetActiveBookingsByHospitalId(long hospitalId)
	{
	  return await databaseContext.Bookings
				  .Where(b => b.HospitalFk == hospitalId && b.IsActive.HasValue && b.IsActive.Value)
				  .Include(b => b.UserFkNavigation)
				  .Include(b => b.PackageFkNavigation)
				  .Include(b => b.VehicleFkNavigation)
				  .Include(b => b.BedTickets.OrderByDescending(bt => bt.DateEntered)).ThenInclude(b => b.EnteredByFkNavigation)
				  .Include(b => b.CovidTestResults.OrderByDescending(ctr => ctr.DateTested))
				  .ToListAsync();
	}

	/// <summary>
	/// Gets the bookings by user.
	/// </summary>
	/// <param name="userId">The user identifier.</param>
	/// <returns></returns>
	public async Task<IList<Booking>> GetBookingsByUser(long userId)
	{
	  return await databaseContext.Bookings
		.Where(b => b.UserFk == userId)
		.Include(b => b.HospitalFkNavigation)
		.Include(b => b.PackageFkNavigation)
		.Include(b => b.VehicleFkNavigation)
		.Include(b => b.BedTickets).ThenInclude(b => b.EnteredByFkNavigation)
		.Include(b => b.CovidTestResults)
		.ToListAsync();
	}

	public async Task UpsertBooking(Booking booking)
	{
	  if (booking.Id == 0)
	  {
		var activeBookings = await databaseContext.Bookings.Where(b => (b.IsActive.HasValue && (b.IsActive.Value == true)) && b.UserFk == booking.UserFk).FirstOrDefaultAsync();
		if (activeBookings == null)
		{
		  await databaseContext.Bookings.AddAsync(booking);
		  databaseContext.Entry(booking).State = EntityState.Added;
		}
		else
		{
		  throw new CustomException("User already have an active reservation.");
		}
	  }
	  else
	  {
		databaseContext.Bookings.Update(booking);
		databaseContext.Entry(booking).State = EntityState.Modified;
	  }
	  await databaseContext.SaveChangesAsync();
	}

	/// <summary>
	/// Removes the booking.
	/// </summary>
	/// <param name="booking">The booking.</param>
	public async Task RemoveBooking(Booking booking)
	{
	  databaseContext.Bookings.Remove(booking);
	  await databaseContext.SaveChangesAsync();
	}
  }
}
