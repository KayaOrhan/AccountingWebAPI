using Microsoft.AspNetCore.Authentication.JwtBearer;
using Muhasebe.Infrastructure.Authentication;
using Muhasebe.WebApi.OptionsSetup;

namespace Muhasebe.WebApi.Configurations
{
    public class AuthenticationAndAuthorizationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        }
    }
}
