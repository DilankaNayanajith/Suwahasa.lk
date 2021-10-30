using Suwahasa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suwahasa.Data.Repositories.Interfaces
{
    public interface IPackagesRepository
    {
        /// <summary>
        /// Gets the package by identifier.
        /// </summary>
        /// <param name="packageId">The package identifier.</param>
        /// <returns></returns>
        Task<Package> GetPackageById(long packageId);

        /// <summary>
        /// Upserts the package.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns></returns>
        Task UpsertPackage(Package package);

        /// <summary>
        /// Deletes the package.
        /// </summary>
        /// <param name="package">The package.</param>
        /// <returns></returns>
        Task DeletePackage(Package package);
    }
}
