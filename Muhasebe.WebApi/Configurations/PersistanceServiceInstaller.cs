using Microsoft.EntityFrameworkCore;
using Muhasebe.Domain.AppEntities.Identity;
using Muhasebe.Persistance.Context;

namespace Muhasebe.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(SectionName));
            });

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
