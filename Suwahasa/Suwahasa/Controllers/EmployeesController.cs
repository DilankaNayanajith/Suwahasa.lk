using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.API.Controllers
{
  [Route("api/Employees")]
  public class EmployeesController : BaseController<EmployeesController>
  {
	/// <summary>
	/// The employees services
	/// </summary>
	protected readonly IEmployeesServices employeesServices;

	/// <summary>
	/// Initializes a new instance of the <see cref="EmployeesController"/> class.
	/// </summary>
	/// <param name="employeesServices">The employees services.</param>
	public EmployeesController(
	  IAuthServices authServices,
	  IHttpContextAccessor httpContextAccessor,
	  IEmployeesServices employeesServices) : base(authServices, httpContextAccessor)
	{
	  this.employeesServices = employeesServices;
	}

	/// <summary>
	/// Gets all employees.
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public async Task<ActionResult<IList<EmployeeDto>>> GetAllEmployees()
	{
	  var employees = await employeesServices.GetAllEmployees();
	  return Ok(employees);
	}

	/// <summary>
	/// Gets the employee by identifier.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	[HttpGet("{employeeId}")]
	public async Task<ActionResult<EmployeeDto>> GetEmployeeById([FromRoute] long employeeId)
	{
	  var employee = await employeesServices.GetEmployeeById(employeeId);
	  return Ok(employee);
	}

	/// <summary>
	/// Searches the employees.
	/// </summary>
	/// <param name="hospitalId">The hospital identifier.</param>
	/// <param name="role">The role.</param>
	/// <returns></returns>
	[HttpGet("search")]
	public async Task<ActionResult<IList<EmployeeDto>>> SearchEmployees([FromQuery] long hospitalId, [FromQuery] string role)
	{
	  var employees = await employeesServices.GetEmployeesByHospitalAndRole(hospitalId, role);
	  return Ok(employees);
	}

	/// <summary>
	/// Upserts the employee.
	/// </summary>
	/// <param name="employee">The employee.</param>
	/// <returns></returns>
	[HttpPost]
	public async Task<ActionResult> UpsertEmployee([FromBody] UpsertEmployeeRequest employee)
	{
	  await employeesServices.UpsertEmployee(employee);
	  return Ok();
	}

	[HttpPost("user")]
	public async Task<ActionResult> CreateUserForEmployee([FromQuery]long employeeId)
	{
	  await employeesServices.CreateAUserByEmployee(employeeId);
	  return Ok();
	}

	[HttpPost("user/reset")]
	public async Task<ActionResult> ResetUserForEmployee([FromQuery] long employeeId)
	{
	  await employeesServices.ResetEmployeeUserAccount(employeeId);
	  return Ok();
	}

	/// <summary>
	/// Deletes the employee.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	[HttpDelete("{employeeId}")]
	public async Task<ActionResult> DeleteEmployee([FromRoute] long employeeId)
	{
	  await employeesServices.DeleteEmployee(employeeId);
	  return Ok();
	}
  }
}
