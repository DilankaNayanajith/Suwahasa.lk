using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.API.Controllers;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Threading.Tasks;

namespace Suwahasa.Controllers
{
  [Route("api/CovidTestResults")]
  public class CovidTestResultsController : BaseController<CovidTestResultsController>
  {
	protected ICovidTestResultsServices covidTestResultsServices;

	public CovidTestResultsController(
	  IAuthServices authServices, 
	  ICovidTestResultsServices covidTestResultsServices,
	  IHttpContextAccessor httpContextAccessor) : base(authServices, httpContextAccessor)
	{
	  this.covidTestResultsServices = covidTestResultsServices;
	}

	[HttpGet("{bookingId}")]
	public async Task<ActionResult> GetCovidTestResultsByBookingId(long bookingId)
	{
	  var results = await covidTestResultsServices.GetCovidTestResultsByBookingId(bookingId);
	  return Ok(results);
	}

	[HttpPost]
	public async Task<ActionResult> UpsertCovidTestResult(UpsertCovidTestResultRequest covidTestResult)
	{
	  await covidTestResultsServices.UpsertCovidTestResult(covidTestResult);
	  return Ok();
	}
  }
}
