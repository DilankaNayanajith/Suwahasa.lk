using Microsoft.EntityFrameworkCore;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories
{
  public class UserRepository : IUserRepository
  {
	private readonly Entities.DatabaseContext databaseContext;

	public UserRepository()
	{
	  databaseContext = new Entities.DatabaseContext();
	}
	public User GetUserByUsername(string username)
	{
	  return databaseContext.Users
		.Where(u => u.Username == username)
		.Include(u => u.EmployeeFkNavigation)
		.FirstOrDefault();
	}

	public async Task<User> GetUserByUsernameAsync(string username)
	{
	  return await databaseContext.Users
		 .Where(u => u.Username == username)
		 .Include(u => u.EmployeeFkNavigation)
		 .FirstOrDefaultAsync();
	}

	public async Task<User> GetUserByEmployeeId(long employeeId)
	{
	  return await databaseContext.Users.Where(u => u.EmployeeFk == employeeId).FirstOrDefaultAsync();
	}

	public async Task<User> GetUserById(long userId)
	{
	  return await databaseContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
	}

	public async Task<User> UpsertUser(User user)
	{
	  if (user.Id == 0)
	  {
		await databaseContext.Users.AddAsync(user);
		user.EmployeeFk = user.EmployeeFk == 0 ? null : user.EmployeeFk;
		databaseContext.Entry(user).State = EntityState.Added;
	  }
	  else
	  {
		databaseContext.Users.Update(user);
		databaseContext.Entry(user).State = EntityState.Modified;
	  }

	  await databaseContext.SaveChangesAsync();
	  return user;
	}


  }
}
