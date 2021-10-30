using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Services.Interfaces
{
  public interface ICovidTestResultsServices
  {
	Task<IList<CovidTestResultDto>> GetCovidTestResultsByBookingId(long bookingId);
	Task UpsertCovidTestResult(UpsertCovidTestResultRequest covidTestResult);
  }
}
