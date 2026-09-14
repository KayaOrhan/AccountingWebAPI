using MediatR;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);

            if (role == null)
            {
                throw new InvalidOperationException("Role not found.");
            }

            await _roleService.DeleteAsync(role);
            return new DeleteRoleResponse();
        }
    }
}
