using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public record GetAllRolesQueryResponse(IList<AppRole> Roles);
}
