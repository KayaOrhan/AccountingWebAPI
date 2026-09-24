
using Mapster;
using Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities;
using Muhasebe.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Muhasebe.Persistance.Services.AppService
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = request.Adapt<Company>();
            company.Id = Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Company> GetCompanyByName(string name)
        {
            return await _context.Set<Company>().FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task MigrateCompanyDatabases()
        {
            var companies = await _context.Set<Company>().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
