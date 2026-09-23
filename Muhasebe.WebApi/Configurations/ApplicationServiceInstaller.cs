using FluentValidation;
using MediatR;
using Muhasebe.Application.Behaviour;

namespace Muhasebe.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Muhasebe.Application.AssemblyReference).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(Muhasebe.Application.AssemblyReference).Assembly);

        }
    }
}
