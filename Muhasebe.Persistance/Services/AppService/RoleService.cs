using Mapster;
using Microsoft.AspNetCore.Identity;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Muhasebe.Application.Services.AppServices;
using Microsoft.EntityFrameworkCore;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Persistance.Services.AppService
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task AddAsync(CreateRoleCommand request)
        {
            AppRole role = request.Adapt<AppRole>();
            role.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteAsync(AppRole appRole)
        {
            if (appRole != null)
            {
                await _roleManager.DeleteAsync(appRole);
            }
        }

        public async Task<IList<AppRole>> GetAllRolesAsync()
        {
            IList<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<AppRole> GetByCode(string code)
        {
            AppRole role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Code == code);
            return role;
        }

        public async Task<AppRole> GetById(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task UpdateAsync(AppRole appRole)
        {
            await _roleManager.UpdateAsync(appRole);
        }
    }
}
