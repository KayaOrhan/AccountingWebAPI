using Muhasebe.Application.Services.AppServices;
using Muhasebe.Application.Services.CompanyServices;
using Muhasebe.Domain;
using Muhasebe.Domain.Repositories.UCAFRepositories;
using Muhasebe.Persistance;
using Muhasebe.Persistance.Repositories.UCAFRepositories;
using Muhasebe.Persistance.Services.AppService;
using Muhasebe.Persistance.Services.CompanyService;

namespace Muhasebe.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion

            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion

            #region Repositories
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion

        }
    }
}
