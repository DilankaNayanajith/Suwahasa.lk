using AutoMapper;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Services;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suwahasa.Common.Exceptions;
using Suwahasa.Common.Utilities;
using Suwahasa.Data.Entities;
using Suwahasa.Common.Models;

namespace Suwahasa.Services
{
  public class AuthServices : BaseService, IAuthServices
  {
	private readonly IUserRepository userRepository;


	public AuthServices(IMapper mapper, IUserRepository userRepository) : base(mapper)
	{
	  this.userRepository = userRepository;
	}

	public async Task<UserDto> CreateUser(RegisterRequest user)
	{
	  var existing = await userRepository.GetUserByUsernameAsync(user.Username);
	  UserDto created = null;
	  if (existing != null)
	  {
		throw new CustomException("Username is in use.");
	  }
	  else
	  {
		user.Password = SecurityUtils.GetHashedPassword(user.Password);
		var nuser = AutoMapperUtility<RegisterRequest, User>.GetMappedObject(user, mapper);
		nuser = await userRepository.UpsertUser(nuser);
		created = AutoMapperUtility<User, UserDto>.GetMappedObject(nuser, mapper);
	  }
	  return created;
	}

	public async Task ResetEmployeeAccountCredentials(User user)
	{
	  user.Password = SecurityUtils.GetHashedPassword(user.Password);
	  await userRepository.UpsertUser(user);
	}

	public async Task<UserDto> Login(LoginRequest loginRequest)
	{
	  var user = await userRepository.GetUserByUsernameAsync(loginRequest.Username);
	  if (user == null)
	  {
		throw new CustomException("User not found.");
	  }
	  else
	  {
		if (SecurityUtils.VerifyPassword(loginRequest.Password, user.Password))
		{
		  var userD = AutoMapperUtility<User, UserDto>.GetMappedObject(user, mapper);
		  return userD;
		}
		else
		{
		  throw new CustomException("Incorrect password.");
		}
	  }
	}

	public UserDto GetUserByUsername(string username)
	{
	  var user = userRepository.GetUserByUsername(username);
	  return AutoMapperUtility<User, UserDto>.GetMappedObject(user, mapper);
	}

	 public AuthUser GetAuthUser(string username)
	{
	  var user = userRepository.GetUserByUsername(username);
	  return AutoMapperUtility<User, AuthUser>.GetMappedObject(user, mapper);
	}

	public AuthUser PassToAuthUser(UserDto user)
	{
	  return new AuthUser
	  {
		City = user.City,
		EmployeeId = user.EmployeeId,
		Id = user.Id,
		Name = user.Name,
		Role = user.Type,
		HospitalId = user.HospitalId
	  };
	}
  }
}
