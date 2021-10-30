using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Services.Interfaces
{
    public interface IVehiclesServices
    {
        /// <summary>
        /// Gets all vehicles.
        /// </summary>
        /// <returns></returns>
        Task<IList<VehicleDto>> GetAllVehicles();

        /// <summary>
        /// Gets the vehicle by identifier.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        Task<VehicleDto> GetVehicleById(long vehicleId);

        /// <summary>
        /// Gets the vehicle by hospital.
        /// </summary>
        /// <param name="hospitalId">The hospital identifier.</param>
        /// <returns></returns>
        Task<IList<VehicleDto>> GetVehicleByHospital(long hospitalId);

        /// <summary>
        /// Upserts the vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle.</param>
        /// <returns></returns>
        Task UpsertVehicle(UpsertVehicleRequest vehicle);

        /// <summary>
        /// Removes the vehicle.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns></returns>
        Task RemoveVehicle(long vehicleId);
    }
}
