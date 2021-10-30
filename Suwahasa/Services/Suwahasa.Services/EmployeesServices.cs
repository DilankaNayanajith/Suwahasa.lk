using AutoMapper;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Exceptions;
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
  public class EmployeesServices : BaseService, IEmployeesServices
  {
	/// <summary>
	/// The employees repository
	/// </summary>
	protected readonly IEmployeesRepository employeesRepository;
	/// <summary>
	/// The authentication services
	/// </summary>
	protected readonly IAuthServices authServices;
	protected readonly IUserRepository userRepository;

	/// <summary>
	/// Initializes a new instance of the <see cref="EmployeesServices"/> class.
	/// </summary>
	/// <param name="mapper">The mapper.</param>
	/// <param name="employeesRepository">The employees repository.</param>
	public EmployeesServices(
	  IMapper mapper, 
	  IEmployeesRepository employeesRepository, 
	  IAuthServices authServices,
	  IUserRepository userRepository) : base(mapper)
	{
	  this.authServices = authServices;
	  this.userRepository = userRepository;
	  this.employeesRepository = employeesRepository;
	}

	/// <summary>
	/// Gets all employees.
	/// </summary>
	/// <returns></returns>
	public async Task<IList<EmployeeDto>> GetAllEmployees()
	{
	  var employees = await employeesRepository.GetAllEmployees();
	  return AutoMapperUtility<IList<Employee>, IList<EmployeeDto>>.GetMappedObject(employees, mapper);
	}

	/// <summary>
	/// Gets the employee by identifier.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	public async Task<EmployeeDto> GetEmployeeById(long employeeId)
	{
	  var employee = await employeesRepository.GetEmployeeById(employeeId);
	  return AutoMapperUtility<Employee, EmployeeDto>.GetMappedObject(employee, mapper);
	}

	/// <summary>
	/// Gets the employees by hospital and role.
	/// </summary>
	/// <param name="hospitalId">The hospital identifier.</param>
	/// <param name="role">The role.</param>
	/// <returns></returns>
	public async Task<IList<EmployeeDto>> GetEmployeesByHospitalAndRole(long hospitalId, string role)
	{
	  var employees = await employeesRepository.GetEmployeesByHospitalAndRole(hospitalId, role);
	  return AutoMapperUtility<IList<Employee>, IList<EmployeeDto>>.GetMappedObject(employees, mapper);
	}

	/// <summary>
	/// Upserts the employee.
	/// </summary>
	/// <param name="employee">The employee.</param>
	public async Task UpsertEmployee(UpsertEmployeeRequest employee)
	{
	  var emp = AutoMapperUtility<UpsertEmployeeRequest, Employee>.GetMappedObject(employee, mapper);
	  await employeesRepository.UpsertEmployee(emp);
	}

	/// <summary>
	/// Deletes the employee.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	public async Task DeleteEmployee(long employeeId)
	{
	  var emp = await employeesRepository.GetEmployeeById(employeeId);
	  await employeesRepository.RemoveEmployee(emp);
	}

	public async Task CreateAUserByEmployee(long employeeId)
	{
	  var employee = await employeesRepository.GetEmployeeById(employeeId);
	  employee.IsAuser = true;
	  await employeesRepository.UpsertEmployee(employee);
	  var user = GetUserByEmployee(employee);
	  await authServices.CreateUser(user);
	}

	public async Task ResetEmployeeUserAccount(long employeeId)
	{
	  var employee = await employeesRepository.GetEmployeeById(employeeId);
	  var user = await userRepository.GetUserByEmployeeId(employeeId);
	  if (user != null)
	  {
		user.Username = employee.Email;
		user.Password = employee.Nic;
		await authServices.ResetEmployeeAccountCredentials(user);
	  }
	  else
	  {
		throw new CustomException("User not found");
	  }
	}

	/// <summary>
	/// Gets the user by employee.
	/// </summary>
	/// <param name="employee">The employee.</param>
	/// <returns></returns>
	private RegisterRequest GetUserByEmployee(Employee employee)
	{
	  var user = new RegisterRequest
	  {
		AddressLine1 = employee.AddressLine1,
		AddressLine2 = employee.AddressLine2,
		Age = 0,
		BloodGroup = "N/A",
		City = employee.City,
		ContactNumber = employee.Phone,
		District = employee.District,
		Email = employee.Email,
		EmployeeId = employee.Id,
		FirstName = employee.FirstName,
		LastName = employee.LastName,
		Nic = employee.Nic,
		ParentOrGuardian = "N/A",
		Password = employee.Nic,
		PostalCode = employee.PostalCode,
		Province = employee.Province,
		Status = "true",
		EmergencyContact = "N/A",
		Type = employee.Role,
		Username = employee.Email
	  };
	  return user;
	}
  }
}
