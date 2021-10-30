using Suwahasa.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories.Interfaces
{
    public interface IVehiclesRepository
    {
        Task<IList<Vehicle>> GetAllVehicles();

        Task<Vehicle> GetVehicleById(long vehicleId);

        Task<IList<Vehicle>> GetVehicleByHospital(Hospital hospital);

        Task UpsertVehicle(Vehicle vehicle);

        Task RemoveVehicle(Vehicle vehicle);
    }
}
