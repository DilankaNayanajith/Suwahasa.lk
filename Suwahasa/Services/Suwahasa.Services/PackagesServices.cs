using AutoMapper;
using Suwahasa.Common.Models;
using Suwahasa.Common.Services;
using Suwahasa.Common.Utilities;
using Suwahasa.Data.Entities;
using Suwahasa.Data.Repositories.Interfaces;
using Suwahasa.Services.Interfaces;
using System.Threading.Tasks;

namespace Suwahasa.Services
{
    public class PackagesServices: BaseService, IPackagesServices
    {
        protected readonly IPackagesRepository packagesRepository;

        public PackagesServices(IMapper mapper, IPackagesRepository packagesRepository): base(mapper)
        {
            this.packagesRepository = packagesRepository;
        }

        public async Task UpsertPackage(UpsertPackageRequest upsertPackagesRequest)
        {
            var package = AutoMapperUtility<UpsertPackageRequest, Package>.GetMappedObject(upsertPackagesRequest, mapper);
            await packagesRepository.UpsertPackage(package);
        }

        public async Task DeletePackage(long packageId)
        {
            var package = await packagesRepository.GetPackageById(packageId);
            await packagesRepository.DeletePackage(package);
        }
    }
}
