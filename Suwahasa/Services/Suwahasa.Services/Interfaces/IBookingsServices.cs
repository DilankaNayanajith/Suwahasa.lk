using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Services.Interfaces
{
  public interface IBookingsServices
  {
	Task<BookingDto> GetBookingById(long bookingId);
	Task<IList<BookingDto>> GetActiveBookingsByHospitalId(long hospitalId);
	Task UpdateBooking(BookingDto bookingDto);
	Task<IList<BookingDto>> GetBookingsByUserId(long userId);
	Task<BookingDto> GetCurrentBookingByUserId(long userId);
	Task CreateBooking(UpsertBookingRequest upsertBookingRequest);
  }
}
