

using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public sealed class GetAllRolesResponse
    {
        public IList<AppRole> Roles { get; set; } = new List<AppRole>();
    }
}
