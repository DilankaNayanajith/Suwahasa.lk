using Suwahasa.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Services.Interfaces
{
    public interface IPackagesServices
    {
        /// <summary>
        /// Upserts the packages.
        /// </summary>
        /// <param name="upsertPackagesRequest">The upsert packages request.</param>
        /// <returns></returns>
        Task UpsertPackage(UpsertPackageRequest upsertPackagesRequest);

        /// <summary>
        /// Deletes the packages.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <returns></returns>
        Task DeletePackage(long packageId);
    }
}
