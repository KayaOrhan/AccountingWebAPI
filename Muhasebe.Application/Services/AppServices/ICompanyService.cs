

using Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Muhasebe.Domain.AppEntities;

namespace Muhasebe.Application.Services.AppServices
{
    public  interface ICompanyService
    {
        Task CreateCompany(CreateCompanyCommand request, CancellationToken cancellationToken);

        Task<Company>GetCompanyByName(string name);

        Task MigrateCompanyDatabases();
    }
}
