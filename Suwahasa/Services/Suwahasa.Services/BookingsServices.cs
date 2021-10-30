using AutoMapper;
using Suwahasa.Common.Models;
using Suwahasa.Common.Services;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Services.Interfaces;
using System.Threading.Tasks;
using Suwahasa.Common.Utilities;
using System;
using System.Collections.Generic;
using Suwahasa.Common.Dtos;
using System.Linq;

namespace Suwahasa.Services
{
  public class BookingsServices: BaseService, IBookingsServices
  {
	private readonly IBookingsRepository bookingsRepository;

	public BookingsServices(IMapper mapper, IBookingsRepository bookingsRepository): base(mapper)
	{
	  this.bookingsRepository = bookingsRepository;
	}

	public async Task<BookingDto> GetBookingById(long bookingId)
	{
	  var booking = await bookingsRepository.GetBookingById(bookingId);
	  return AutoMapperUtility<Booking, BookingDto>.GetMappedObject(booking, mapper);
	}

	public async Task<IList<BookingDto>> GetActiveBookingsByHospitalId(long hospitalId)
	{
	  var bookings = await bookingsRepository.GetActiveBookingsByHospitalId(hospitalId);
	  return AutoMapperUtility<IList<Booking>, IList<BookingDto>>.GetMappedObject(bookings, mapper);
	}

	public async Task<IList<BookingDto>> GetBookingsByUserId(long userId)
	{
	  var bookings = await bookingsRepository.GetBookingsByUser(userId);
	  return AutoMapperUtility<IList<Booking>, IList<BookingDto>>.GetMappedObject(bookings, mapper);
	}

	public async Task<BookingDto> GetCurrentBookingByUserId(long userId)
	{
	  var bookings = await bookingsRepository.GetBookingsByUser(userId);
	  var booking = bookings.Where(b => b.IsActive.HasValue && b.IsActive.Value).OrderByDescending(b => b.DateCreated).FirstOrDefault();
	  return AutoMapperUtility<Booking, BookingDto>.GetMappedObject(booking, mapper);
	}

	public async Task CreateBooking(UpsertBookingRequest upsertBookingRequest)
	{
	  var booking = AutoMapperUtility<UpsertBookingRequest, Booking>.GetMappedObject(upsertBookingRequest, mapper);
	  booking.DateCreated = DateTime.Now;
	  await bookingsRepository.UpsertBooking(booking);
	}

	public async Task UpdateBooking(BookingDto bookingDto)
	{
	  var booking = AutoMapperUtility<BookingDto, Booking>.GetMappedObject(bookingDto, mapper);
	  await bookingsRepository.UpsertBooking(booking);
	}
  }
}
