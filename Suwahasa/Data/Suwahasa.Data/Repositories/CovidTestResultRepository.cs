using Microsoft.EntityFrameworkCore;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories
{
  public class CovidTestResultRepository: ICovidTestResultsRepository
  {
	private readonly Entities.DatabaseContext databaseContext;

	public CovidTestResultRepository()
	{
	  databaseContext = new Entities.DatabaseContext();
	}

	public async Task<IList<CovidTestResult>> GetCovidTestResultsByBookingId(long bookingId)
	{
	  var testResults = await databaseContext.CovidTestResults
								.Where(c => c.BookingFk == bookingId)
								.OrderByDescending(c => c.DateTested)
								.ToListAsync();
	  return testResults;
	}

	public async Task UpsertCovidTestResult(CovidTestResult covidTestResult)
	{
	  if (covidTestResult.Id == 0)
	  {
		await databaseContext.CovidTestResults.AddAsync(covidTestResult);
		databaseContext.Entry(covidTestResult).State = EntityState.Added;
	  }
	  else
	  {
		databaseContext.CovidTestResults.Update(covidTestResult);
		databaseContext.Entry(covidTestResult).State = EntityState.Modified;
	  }
	  await databaseContext.SaveChangesAsync();
	}
  }
}
