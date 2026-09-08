using Muhasebe.Application.Abstractions;
using Muhasebe.Infrastructure.Authentication;

namespace Muhasebe.WebApi.Configurations
{
    public class InfrastructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}
