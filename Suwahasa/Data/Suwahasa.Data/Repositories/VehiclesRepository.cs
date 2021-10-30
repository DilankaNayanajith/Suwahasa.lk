using Microsoft.EntityFrameworkCore;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories
{
    public class VehiclesRepository: IVehiclesRepository
    {
        protected readonly Entities.DatabaseContext databaseContext;

        public VehiclesRepository()
        {
            this.databaseContext = new Entities.DatabaseContext();
        }

        public async Task<IList<Vehicle>> GetAllVehicles()
        {
            return await databaseContext.Vehicles
                            .Include(v => v.DriverFkNavigation)
                            .Include(v => v.HospitalFkNavigation).ToListAsync();
        }

        public async Task<Vehicle> GetVehicleById(long vehicleId)
        {
            return await databaseContext.Vehicles.Where(v => v.Id == vehicleId).FirstOrDefaultAsync();
        }

        public async Task<IList<Vehicle>> GetVehicleByHospital(Hospital hospital)
        {
            return await databaseContext.Vehicles.Where(v => v.HospitalFk == hospital.Id).ToListAsync();
        }

        public async Task UpsertVehicle(Vehicle vehicle)
        {
            if (vehicle.Id == 0)
            {
                await databaseContext.Vehicles.AddAsync(vehicle);
                databaseContext.Entry(vehicle).State = EntityState.Added;
            }else
            {
                databaseContext.Vehicles.Update(vehicle);
                databaseContext.Entry(vehicle).State = EntityState.Modified;
            }

            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveVehicle(Vehicle vehicle)
        {
            databaseContext.Vehicles.Remove(vehicle);
            await databaseContext.SaveChangesAsync();
        }
    }
}
