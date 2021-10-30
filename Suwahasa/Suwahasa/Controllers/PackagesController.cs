using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Threading.Tasks;

namespace Suwahasa.API.Controllers
{
    [Route("api/Packages")]
    public class PackagesController : BaseController<PackagesController>
  {
        protected IPackagesServices packagesServices;

        public PackagesController(
          IAuthServices authServices, 
          IPackagesServices packagesServices, 
          IHttpContextAccessor httpContextAccessor): base(authServices, httpContextAccessor)
        {
            this.packagesServices = packagesServices;
        }

        [HttpPost]
        public async Task<ActionResult> UpsertPackage([FromBody]UpsertPackageRequest upsertPackageRequest)
        {
            await packagesServices.UpsertPackage(upsertPackageRequest);
            return Ok();
        }

        [HttpDelete("{packageId}")]
        public async Task<ActionResult> DeletePackage([FromRoute]long packageId)
        {
            await packagesServices.DeletePackage(packageId);
            return Ok();
        }
    }
}
