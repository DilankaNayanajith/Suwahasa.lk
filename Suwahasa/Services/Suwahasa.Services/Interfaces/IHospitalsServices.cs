using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Services.Interfaces
{
    public interface IHospitalsServices
    {
        Task<IList<HospitalDto>> GetAllHospitals();
        Task<HospitalDto> GetHospitalById(long id);
        Task<IList<HospitalDto>> GetHospitalsByCity(string city);
        Task UpsertHospital(UpsertHospitalRequest hospital);
        Task RemoveHospital(long hospitalId);
    }
}
