

using Microsoft.EntityFrameworkCore;
using Muhasebe.Domain;
using Muhasebe.Domain.AppEntities;
using Muhasebe.Persistance.Context;

namespace Muhasebe.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appDbContext;

        public ContextService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public DbContext CreateDbContextInstance(string companyId)
        {
            Company company = _appDbContext.Set<Company>().Find(companyId);
            if (company == null)
            {
                throw new ArgumentException($"Company with ID {companyId} not found.");
            }
            return new CompanyDbContext(company);
        }
    }
}
