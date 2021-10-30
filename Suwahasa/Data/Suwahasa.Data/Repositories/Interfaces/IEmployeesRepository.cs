using Suwahasa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        Task<IList<Employee>> GetAllEmployees();

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        Task<Employee> GetEmployeeById(long employeeId);

        /// <summary>
        /// Gets the employees by hospital and role.
        /// </summary>
        /// <param name="hospitalId">The hospital identifier.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        Task<IList<Employee>> GetEmployeesByHospitalAndRole(long hospitalId, string role);

        /// <summary>
        /// Upserts the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        Task UpsertEmployee(Employee employee);

        /// <summary>
        /// Removes the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        Task RemoveEmployee(Employee employee);
    }
}
