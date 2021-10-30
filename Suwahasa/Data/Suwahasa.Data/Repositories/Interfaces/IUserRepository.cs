using Suwahasa.Data.Entities;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories.Interfaces
{
  public interface IUserRepository
  {
	/// <summary>
	/// Gets the user by username.
	/// </summary>
	/// <param name="username">The username.</param>
	/// <returns></returns>
	User GetUserByUsername(string username);

	/// <summary>
	/// Gets the user by username asynchronous.
	/// </summary>
	/// <param name="username">The username.</param>
	/// <returns></returns>
	Task<User> GetUserByUsernameAsync(string username);

	/// <summary>
	/// Gets the user by identifier.
	/// </summary>
	/// <param name="userId">The user identifier.</param>
	/// <returns></returns>
	Task<User> GetUserById(long userId);

	/// <summary>
	/// Gets the user by employee identifier.
	/// </summary>
	/// <param name="employeeId">The employee identifier.</param>
	/// <returns></returns>
	Task<User> GetUserByEmployeeId(long employeeId);

	/// <summary>
	/// Upserts the user.
	/// </summary>
	/// <param name="user">The user.</param>
	/// <returns></returns>
	Task<User> UpsertUser(User user);
  }
}
