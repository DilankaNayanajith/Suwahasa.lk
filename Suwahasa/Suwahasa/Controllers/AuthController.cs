using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Suwahasa.API.Controllers
{
  [Route("api/Auth")]
  public class AuthController : BaseController<AuthController>
  {
	public AuthController(
		IAuthServices authServices,
		IHttpContextAccessor httpContextAccessor) : base(authServices, httpContextAccessor)
	{
	  this.authServices = authServices;
	  this.httpContextAccessor = httpContextAccessor;
	}

	[AllowAnonymous]
	[HttpPost("login")]
	public async Task<ActionResult> Login(LoginRequest loginRequest)
	{
	  var user = await authServices.Login(loginRequest);
	  if (user != null)
	  {
		SetCookie(user);
		return Ok(authServices.PassToAuthUser(user));
	  }
	  else
	  {
		return StatusCode(500);
	  }
	}

	[AllowAnonymous]
	[HttpPost("register")]
	public async Task<ActionResult> Register(RegisterRequest registerRequest)
	{
	  var user = await authServices.CreateUser(registerRequest);
	  if (user != null)
	  {
		SetCookie(user);
		return Ok(authServices.PassToAuthUser(user));
	  }
	  else return StatusCode(500);
	}

	[HttpPost("logout")]
	public ActionResult Signout()
	{
	  HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
	  return Ok();
	}

	[AllowAnonymous]
	[HttpGet]
	public ActionResult Check()
	{
	  if (currentUser != null)
		return Ok(currentUser);
	  else
		return Unauthorized();
	}

	private void SetCookie(UserDto user)
	{
	  var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Username)
				};
	  var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
	  var principal = new ClaimsPrincipal(identity);
	  var props = new AuthenticationProperties();
	  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
	  HttpContext.Session.SetString("signedInUser", JsonConvert.SerializeObject(user));
	  SetCurrentUser();
	}
  }
}
