using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.API.Controllers;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Threading.Tasks;

namespace Suwahasa.Controllers
{
  [Route("api/BedTickets")]
  public class BedTicketsController : BaseController<BedTicketsController>
  {
	protected IBedTicketsServices bedTicketsServices;

	public BedTicketsController(
	  IAuthServices authServices,
	  IBedTicketsServices bedTicketsServices,
	  IHttpContextAccessor httpContextAccessor) : base(authServices, httpContextAccessor)
	{
	  this.bedTicketsServices = bedTicketsServices;
	}

	[HttpGet("{bookingId}")]
	public async Task<ActionResult> GetTechTicketsByBookingId([FromRoute]long bookingId)
	{
	  var bookings = await bedTicketsServices.GetBedTicketsByBookingId(bookingId);
	  return Ok(bookings);
	}

	[HttpPost]
	public async Task<ActionResult> UpsertBedTicket([FromBody]UpsertBedTicketRequest bedTicketDto)
	{
	  await bedTicketsServices.UpsertBedTicket(bedTicketDto);
	  return Ok();
	}
  }
}
