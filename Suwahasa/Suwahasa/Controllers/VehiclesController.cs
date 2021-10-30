using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.API.Controllers
{
    [Route("api/vehicles")]
    public class VehiclesController : BaseController<VehiclesController>
  {
        protected readonly IVehiclesServices vehiclesServices;

        public VehiclesController(
          IAuthServices authServices, 
          IVehiclesServices vehiclesServices, 
          IHttpContextAccessor httpContextAccessor): base(authServices, httpContextAccessor)
        {
            this.vehiclesServices = vehiclesServices;
        }

        [HttpGet]
        public async Task<ActionResult<IList<VehicleDto>>> GetAllVehicles()
        {
            var vehicles = await vehiclesServices.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{vehicleId}")]
        public async Task<ActionResult<VehicleDto>> GetVehicleById([FromRoute] long vehicleId)
        {
            var vehicle = await vehiclesServices.GetVehicleById(vehicleId);
            return Ok(vehicle);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IList<VehicleDto>>> GetVehicleByHospital([FromQuery] long hospitalId)
        {
            var vehicles = await vehiclesServices.GetVehicleByHospital(hospitalId);
            return Ok(vehicles);
        }

        [HttpPost]
        public async Task UpsertVehicle([FromBody] UpsertVehicleRequest vehicle)
        {
            await vehiclesServices.UpsertVehicle(vehicle);
        }

        [HttpDelete("{vehicleId}")]
        public async Task RemoveVehicle([FromRoute] long vehicleId)
        {
            await vehiclesServices.RemoveVehicle(vehicleId);
        }
    }
}
