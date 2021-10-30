using Suwahasa.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Suwahasa.Data.Repositories
{
    public class HospitalsRepository: IHospitalsRepository
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly Entities.DatabaseContext databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="HospitalsRepository"/> class.
        /// </summary>
        public HospitalsRepository()
        {
            this.databaseContext = new Entities.DatabaseContext();
        }

        /// <summary>
        /// Gets all hospitals.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Hospital>> GetAllHospitals(){
            return await databaseContext.Hospitals.ToListAsync();
        }

        /// <summary>
        /// Gets the hospital by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<Hospital> GetHospitalById(long Id){
            return await databaseContext.Hospitals.Where(h => h.Id == Id)
                .Include(h => h.Employees)
                .Include(h => h.Vehicles)
                .Include(h => h.Packages)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the hospitals by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<IList<Hospital>> GetHospitalsByCity(string city){
            var hospitals = await databaseContext.Hospitals.ToListAsync();
            return hospitals.Where(h => h.City.ToLowerInvariant().Contains(city)).ToList();
        }

        /// <summary>
        /// Upserts the hospital.
        /// </summary>
        /// <param name="hospital">The hospital.</param>
        public async Task UpsertHospital(Hospital hospital)
        {
            if (hospital.Id == 0)
            {
                await databaseContext.Hospitals.AddAsync(hospital);
                databaseContext.Entry(hospital).State = EntityState.Added;
            }else{
                databaseContext.Hospitals.Update(hospital);
                databaseContext.Entry(hospital).State = EntityState.Modified;
            }
            await databaseContext.SaveChangesAsync();
        }

        /// <summary>
        /// Removes the hospital.
        /// </summary>
        /// <param name="hospital">The hospital.</param>
        public async Task RemoveHospital(Hospital hospital)
        {
            databaseContext.Hospitals.Remove(hospital);
            await databaseContext.SaveChangesAsync();
        }
    }
}
