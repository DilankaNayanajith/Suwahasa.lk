using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Services.Interfaces
{
  public interface IEmployeesServices
  {
	/// <summary>
	/// Gets all employees.
	/// </summary>
	/// <returns></returns>
	Task<IList<EmployeeDto>> GetAllEmployees();

	/// <summary>
	/// Gets the employee by identifier.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	Task<EmployeeDto> GetEmployeeById(long employeeId);

	/// <summary>
	/// Gets the employees by hospital and role.
	/// </summary>
	/// <param name="hospitalId">The hospital identifier.</param>
	/// <param name="role">The role.</param>
	/// <returns></returns>
	Task<IList<EmployeeDto>> GetEmployeesByHospitalAndRole(long hospitalId, string role);

	/// <summary>
	/// Upserts the employee.
	/// </summary>
	/// <param name="employee">The employee.</param>
	/// <returns></returns>
	Task UpsertEmployee(UpsertEmployeeRequest employee);

	/// <summary>
	/// Deletes the employee.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	Task DeleteEmployee(long employeeId);

	/// <summary>
	/// Creates a user by employee.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	Task CreateAUserByEmployee(long employeeId);

	/// <summary>
	/// Resets the employee user account.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	Task ResetEmployeeUserAccount(long employeeId);
  }
}
