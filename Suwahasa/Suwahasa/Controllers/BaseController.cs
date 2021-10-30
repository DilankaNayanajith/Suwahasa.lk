using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Security.Claims;

namespace Suwahasa.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    public class BaseController<T> : ControllerBase where  T : BaseController<T>
    {
        protected IHttpContextAccessor httpContextAccessor;
        protected IAuthServices authServices;
        protected AuthUser currentUser;

        public BaseController(IAuthServices authServices, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.authServices = authServices;
            SetCurrentUser();
        }

        protected void SetCurrentUser()
        {
            var username = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username == null)
            {
                this.currentUser = null;
            }
            else
            {
                currentUser = authServices.GetAuthUser(username);
            }
        }
    }
}
