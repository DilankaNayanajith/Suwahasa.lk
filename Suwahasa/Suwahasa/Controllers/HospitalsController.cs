using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.API.Controllers
{
    [Route("api/Hospitals")]
    public class HospitalsController : BaseController<HospitalsController>
  {
        /// <summary>
        /// The hospital services
        /// </summary>
        private readonly IHospitalsServices hospitalServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="HospitalsController"/> class.
        /// </summary>
        /// <param name="hospitalServices">The hospital services.</param>
        public HospitalsController(
          IAuthServices authServices, 
          IHospitalsServices hospitalServices, 
          IHttpContextAccessor httpContextAccessor): base(authServices, httpContextAccessor)
    {
            this.hospitalServices = hospitalServices;
        }

        /// <summary>
        /// Gets all hospitals.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<HospitalDto>>> GetAllHospitals(){
            return Ok(await hospitalServices.GetAllHospitals());
        }

        /// <summary>
        /// Gets the hospital by identifier.
        /// </summary>
        /// <param name="hospitalId">The hospital identifier.</param>
        /// <returns></returns>
        [HttpGet("{hospitalId}")]
        public async Task<ActionResult<string>> GetHospitalById(long hospitalId)
        {
            var hospital = await hospitalServices.GetHospitalById(hospitalId);
            //var josn = Newtonsoft.Json.JsonConvert.SerializeObject(hospital);
            return Ok(hospital);
        }

        /// <summary>
        /// Gets the hospitals by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<ActionResult<IList<HospitalDto>>> GetHospitalsByCity([FromQuery]string city)
        {
            city = city == null ? "" : city;
            return Ok(await hospitalServices.GetHospitalsByCity(city.ToLowerInvariant()));
        }

        /// <summary>
        /// Upserts the hospital.
        /// </summary>
        /// <param name="hospital">The hospital.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpsertHospital([FromBody]UpsertHospitalRequest hospital){
            await hospitalServices.UpsertHospital(hospital);
            return Ok();
        }

        /// <summary>
        /// Deletes the hospital.
        /// </summary>
        /// <param name="hospitalId">The hospital identifier.</param>
        /// <returns></returns>
        [HttpDelete("{hospitalId}")]
        public async Task<ActionResult> DeleteHospital([FromRoute]long hospitalId)
        {
            await hospitalServices.RemoveHospital(hospitalId);
            return Ok();
        }
    }
}
