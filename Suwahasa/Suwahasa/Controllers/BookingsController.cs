using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.API.Controllers;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suwahasa.Controllers
{
  [Route("api/Bookings")]
  public class BookingsController: BaseController<BookingsController>
  {
	private readonly IBookingsServices bookingsServices;

	public BookingsController(
	  IAuthServices authServices,
	  IHttpContextAccessor httpContextAccessor,
	  IBookingsServices bookingsServices) : base(authServices, httpContextAccessor)
	{
	  this.authServices = authServices;
	  this.httpContextAccessor = httpContextAccessor;
	  this.bookingsServices = bookingsServices;
	}

	[HttpGet("{bookingId}")]
	public async Task<ActionResult> GetBookingById([FromRoute]long bookingId)
	{
	  var booking = await bookingsServices.GetBookingById(bookingId);
	  return Ok(booking);
	}

	[HttpGet("hospital/{hospitalId}")]
	public async Task<ActionResult> GetActiveBookingsByHospitalId(long hospitalId)
	{
	  var bookings = await bookingsServices.GetActiveBookingsByHospitalId(hospitalId);
	  return Ok(bookings);
	}

	[HttpGet("user/{userId}")]
	public async Task<ActionResult> GetBookingsByUser([FromRoute] long userId)
	{
	  var bookings = await bookingsServices.GetBookingsByUserId(userId);
	  return Ok(bookings);
	}

	[HttpGet("user/{userId}/active")]
	public async Task<ActionResult> GetActiveBookingsByUser([FromRoute] long userId)
	{
	  var bookings = await bookingsServices.GetCurrentBookingByUserId(userId);
	  return Ok(bookings);
	}

	[HttpPost]
	public async Task<ActionResult> CreateBooking([FromBody]UpsertBookingRequest upsertBookingRequest)
	{
	  await bookingsServices.CreateBooking(upsertBookingRequest);
	  return Ok();
	}

	[HttpPut]
	public async Task<ActionResult> UpdateBooking([FromBody]BookingDto bookingDto)
	{
	  await bookingsServices.UpdateBooking(bookingDto);
	  return Ok();
	}
  }
}
