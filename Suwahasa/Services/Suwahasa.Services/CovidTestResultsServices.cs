using AutoMapper;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Common.Services;
using Suwahasa.Common.Utilities;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Services
{
  public class CovidTestResultsServices: BaseService, ICovidTestResultsServices
  {
	protected readonly ICovidTestResultsRepository covidTestResultsRepository;

	public CovidTestResultsServices(IMapper mapper, ICovidTestResultsRepository covidTestResultsRepository): base(mapper)
	{
	  this.covidTestResultsRepository = covidTestResultsRepository;
	}

	public async Task<IList<CovidTestResultDto>> GetCovidTestResultsByBookingId(long bookingId)
	{
	  var results = await covidTestResultsRepository.GetCovidTestResultsByBookingId(bookingId);
	  return AutoMapperUtility<IList<CovidTestResult>, IList<CovidTestResultDto>>.GetMappedObject(results, mapper);
	}

	public async Task UpsertCovidTestResult(UpsertCovidTestResultRequest covidTestResult)
	{
	  var result = AutoMapperUtility<UpsertCovidTestResultRequest, CovidTestResult>.GetMappedObject(covidTestResult, mapper);
	  await covidTestResultsRepository.UpsertCovidTestResult(result);
	}
  }
}
