using Suwahasa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories.Interfaces
{
  public interface IBookingsRepository
  {
	Task<Booking> GetBookingById(long bookingId);

	Task<IList<Booking>> GetActiveBookingsByHospitalId(long hospitalId);

	Task<IList<Booking>> GetBookingsByUser(long userId);

	/// <summary>
	/// Upserts the booking.
	/// </summary>
	/// <param name="booking">The booking.</param>
	/// <returns></returns>
	Task UpsertBooking(Booking booking);

	/// <summary>
	/// Removes the booking.
	/// </summary>
	/// <param name="booking">The booking.</param>
	/// <returns></returns>
	Task RemoveBooking(Booking booking);
  }
}
