
using Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

namespace Muhasebe.Application.Services.CompanyServices
{
    public interface IUCAFService
    {
        Task CreateUCAFAsync(CreateUCAFCommand request);
    }
}
