using Microsoft.EntityFrameworkCore;
using Muhasebe.Domain;
using Muhasebe.Persistance.Context;

namespace Muhasebe.Persistance
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CompanyDbContext _companyDbContext;
        public void SetCompanyDbContextInstance(DbContext context)
        {
            _companyDbContext = (CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int count = await _companyDbContext.SaveChangesAsync();
            return count;
        }
    }
}
