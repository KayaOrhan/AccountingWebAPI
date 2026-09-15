
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleCommand request);
        Task UpdateAsync(AppRole appRole);
        Task DeleteAsync(AppRole appRole);
        Task<IList<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetById(string id);
        Task<AppRole> GetByCode(string code);
    }
}
