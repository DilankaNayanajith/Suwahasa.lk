using AutoMapper;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Services;
using Suwahasa.Common.Utilities;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Suwahasa.Common.Models;

namespace Suwahasa.Services
{
  public class BedTicketsServices: BaseService, IBedTicketsServices
  {
	protected readonly IBedTicketsRepository bedTicketsRepository;

	public BedTicketsServices(IMapper mapper, IBedTicketsRepository bedTicketsRepository): base(mapper)
	{
	  this.bedTicketsRepository = bedTicketsRepository;
	}

	public async Task<IList<BedTicketDto>> GetBedTicketsByBookingId(long bookingId)
	{
	  var tickets = await bedTicketsRepository.GetBedTicketsByBookingId(bookingId);
	  return AutoMapperUtility<IList<BedTicket>, IList<BedTicketDto>>.GetMappedObject(tickets, mapper);
	}

	public async Task UpsertBedTicket(UpsertBedTicketRequest bedTicket)
	{
	  var ticket = AutoMapperUtility<UpsertBedTicketRequest, BedTicket>.GetMappedObject(bedTicket, mapper);
	  await bedTicketsRepository.UpsertBedTicket(ticket);
	}
  }
}
