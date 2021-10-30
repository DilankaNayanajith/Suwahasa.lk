using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Suwahasa.Data.Repositories
{
    public class EmployeesRepository: IEmployeesRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly Entities.DatabaseContext databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesRepository"/> class.
        /// </summary>
        public EmployeesRepository(){
            this.databaseContext = new Entities.DatabaseContext();
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Employee>> GetAllEmployees(){
            return await databaseContext.Employees.Include(e => e.HospitalFkNavigation).ToListAsync();
        }

        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeById(long employeeId)
        {
            return await databaseContext.Employees.Where(e => e.Id == employeeId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the employees by hospital and role.
        /// </summary>
        /// <param name="hospitalId">The hospital identifier.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public async Task<IList<Employee>> GetEmployeesByHospitalAndRole(long hospitalId, string role)
        {
            var list = await databaseContext.Employees.Where(e => e.HospitalFk == hospitalId).ToListAsync();
            return list.Where(e => e.Role == role).ToList();
        }

        /// <summary>
        /// Upserts the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public async Task UpsertEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                await databaseContext.Employees.AddAsync(employee);
                databaseContext.Entry(employee).State = EntityState.Added;
            }else
            {
                databaseContext.Employees.Update(employee);
                databaseContext.Entry(employee).State = EntityState.Modified;
            }
            await databaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public async Task RemoveEmployee(Employee employee)
        {
            databaseContext.Employees.Remove(employee);
            await databaseContext.SaveChangesAsync();
        }
    }
}
