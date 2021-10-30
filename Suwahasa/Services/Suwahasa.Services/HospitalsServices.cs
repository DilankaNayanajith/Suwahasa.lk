using AutoMapper;
using Suwahasa.Common.Dtos;
using Suwahasa.Common.Models;
using Suwahasa.Common.Services;
using Suwahasa.Common.Utilities;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories;
using Suwahasa.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suwahasa.Services
{
    public class HospitalsServices: BaseService, IHospitalsServices
    {
        protected readonly IHospitalsRepository hospitalRepository;

        public HospitalsServices(IMapper mapper, IHospitalsRepository hospitalRepository) : base(mapper)
        {
            this.hospitalRepository = hospitalRepository;
        }

        public async Task<IList<HospitalDto>> GetAllHospitals(){
            var hospitals = await hospitalRepository.GetAllHospitals();
            return AutoMapperUtility<IList<Hospital>, IList<HospitalDto>>.GetMappedObject(hospitals, mapper);
        }

        public async Task<HospitalDto> GetHospitalById(long id){
            var hospital = await hospitalRepository.GetHospitalById(id);
            return AutoMapperUtility<Hospital, HospitalDto>.GetMappedObject(hospital, mapper);
        }

        public async Task<IList<HospitalDto>> GetHospitalsByCity(string city){
            IList<Hospital> hospitals = new List<Hospital>();
            if (city == "")
            {
                hospitals = await hospitalRepository.GetAllHospitals();
            }else{
                hospitals = await hospitalRepository.GetHospitalsByCity(city);
            }
            return AutoMapperUtility<IList<Hospital>, IList<HospitalDto>>.GetMappedObject(hospitals, mapper);
        }

        public async Task UpsertHospital(UpsertHospitalRequest hospital)
        {
            var hos = AutoMapperUtility<UpsertHospitalRequest, Hospital>.GetMappedObject(hospital, mapper);
            await hospitalRepository.UpsertHospital(hos);
        }

        public async Task RemoveHospital(long hospitalId){
            var hospital = await hospitalRepository.GetHospitalById(hospitalId);
            await hospitalRepository.RemoveHospital(hospital);
        }
    }
}
