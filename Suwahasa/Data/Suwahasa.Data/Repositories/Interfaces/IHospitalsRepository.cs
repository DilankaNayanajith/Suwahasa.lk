using Suwahasa.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories
{
    public interface IHospitalsRepository
    {
        /// <summary>
        /// Gets all hospitals.
        /// </summary>
        /// <returns></returns>
        Task<IList<Hospital>> GetAllHospitals();

        /// <summary>
        /// Gets the hospital by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<Hospital> GetHospitalById(long Id);

        /// <summary>
        /// Gets the hospitals by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Task<IList<Hospital>> GetHospitalsByCity(string city);

        /// <summary>
        /// Upserts the hospital.
        /// </summary>
        /// <param name="hospital">The hospital.</param>
        Task UpsertHospital(Hospital hospital);

        /// <summary>
        /// Removes the hospital.
        /// </summary>
        /// <param name="hospital">The hospital.</param>
        Task RemoveHospital(Hospital hospitalId);
    }
}
