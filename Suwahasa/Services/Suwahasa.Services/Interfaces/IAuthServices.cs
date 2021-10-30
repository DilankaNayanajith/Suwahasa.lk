using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Data.Entities;
using System.Threading.Tasks;

namespace Suwahasa.Services.Interfaces
{
  public interface IAuthServices
  {
	/// <summary>
	/// Creates the user.
	/// </summary>
	/// <param name="user">The user.</param>
	/// <returns></returns>
	Task<UserDto> CreateUser(RegisterRequest user);
	/// <summary>
	/// Logins the specified login request.
	/// </summary>
	/// <param name="loginRequest">The login request.</param>
	/// <returns></returns>
	Task<UserDto> Login(LoginRequest loginRequest);

	/// <summary>
	/// Gets the user by username.
	/// </summary>
	/// <param name="username">The username.</param>
	/// <returns></returns>
	UserDto GetUserByUsername(string username);

	/// <summary>
	/// Gets the authentication user.
	/// </summary>
	/// <param name="username">The username.</param>
	/// <returns></returns>
	AuthUser GetAuthUser(string username);

	/// <summary>
	/// Resets the employee account credentials.
	/// </summary>
	/// <param name="user">The user.</param>
	/// <returns></returns>
	Task ResetEmployeeAccountCredentials(User user);

	/// <summary>
	/// Passes to authentication user.
	/// </summary>
	/// <param name="user">The user.</param>
	/// <returns></returns>
	AuthUser PassToAuthUser(UserDto user);
  }
}
