
using Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Muhasebe.Domain.CompanyEntities;

namespace Muhasebe.Application.Services.CompanyServices
{
    public interface IUCAFService
    {
        Task CreateUCAFAsync(CreateUCAFCommand request, CancellationToken cancellationToken);

        Task<UniformChartOfAccount> GetByCode(string code);
    }
}
