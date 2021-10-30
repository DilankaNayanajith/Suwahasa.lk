using AutoMapper;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Common.Services;
using Suwahasa.Common.Utilities;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Services
{
    public class VehiclesServices: BaseService, IVehiclesServices
    {
        protected readonly IVehiclesRepository vehiclesRepository;
        protected readonly IHospitalsRepository hospitalsRepository;
        
        public VehiclesServices(IMapper mapper, IVehiclesRepository vehiclesRepository, IHospitalsRepository hospitalsRepository) : base(mapper)
        {
            this.vehiclesRepository = vehiclesRepository;
            this.hospitalsRepository = hospitalsRepository;
        }

        public async Task<IList<VehicleDto>> GetAllVehicles()
        {
            var vehicles = await vehiclesRepository.GetAllVehicles();
            return AutoMapperUtility<IList<Vehicle>, IList<VehicleDto>>.GetMappedObject(vehicles, mapper);
        }

        public async Task<VehicleDto> GetVehicleById(long vehicleId)
        {
            var vehicle = await vehiclesRepository.GetVehicleById(vehicleId);
            return AutoMapperUtility<Vehicle, VehicleDto>.GetMappedObject(vehicle, mapper);
        }

        public async Task<IList<VehicleDto>> GetVehicleByHospital(long hospitalId)
        {
            var hospital = await hospitalsRepository.GetHospitalById(hospitalId);
            var vehicles = await vehiclesRepository.GetVehicleByHospital(hospital);
            return AutoMapperUtility<IList<Vehicle>, IList<VehicleDto>>.GetMappedObject(vehicles, mapper);
        }

        public async Task UpsertVehicle(UpsertVehicleRequest vehicle)
        {
            var veh = AutoMapperUtility<UpsertVehicleRequest, Vehicle>.GetMappedObject(vehicle, mapper);
            await vehiclesRepository.UpsertVehicle(veh);
        }

        public async Task RemoveVehicle(long vehicleId)
        {
            var vehicle = await vehiclesRepository.GetVehicleById(vehicleId);
            await vehiclesRepository.RemoveVehicle(vehicle);
        }
    }
}
