using Suwahasa.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories.Interfaces
{
  public interface ICovidTestResultsRepository
  {
	Task<IList<CovidTestResult>> GetCovidTestResultsByBookingId(long bookingId);
	Task UpsertCovidTestResult(CovidTestResult covidTestResult);
  }
}
