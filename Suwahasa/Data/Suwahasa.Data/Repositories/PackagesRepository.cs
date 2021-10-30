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
    public class PackagesRepository: IPackagesRepository
    {
        private readonly Entities.DatabaseContext databaseContext;

        public PackagesRepository()
        {
            databaseContext = new Entities.DatabaseContext();
        }

        public async Task<Package> GetPackageById(long packageId)
        {
            return await databaseContext.Packages.Where(p => p.Id == packageId).FirstOrDefaultAsync();
        }

        public async Task UpsertPackage(Package package){
            if (package.Id == 0)
            {
                await databaseContext.Packages.AddAsync(package);
                databaseContext.Entry(package).State = EntityState.Added;
            }else
            {
                databaseContext.Packages.Update(package);
                databaseContext.Entry(package).State = EntityState.Modified;
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeletePackage(Package package){
            databaseContext.Packages.Remove(package);
            databaseContext.Entry(package).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await databaseContext.SaveChangesAsync();
        }
    }
}
