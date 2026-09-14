using MediatR;
using Muhasebe.Domain.AppEntities.Identity;
using Muhasebe.Application.Services.AppServices;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public sealed class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            IList<AppRole> roles = await _roleService.GetAllRolesAsync();

            return new GetAllRolesResponse
            {
                Roles = roles
            };

        }
    }
}
