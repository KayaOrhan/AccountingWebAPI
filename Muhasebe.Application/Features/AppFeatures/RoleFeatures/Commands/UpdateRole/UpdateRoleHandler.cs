using MediatR;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);

            if (role == null)
            {
                return new UpdateRoleResponse { Message = "Role not found." };
            }

            if (role.Code == request.Code && role.Name == request.Name)
            {
                return new UpdateRoleResponse { Message = "No changes detected." };
            }

            if (role.Code != request.Code)
            {
                AppRole existingRoleWithCode = await _roleService.GetByCode(request.Code);
                if (existingRoleWithCode != null && existingRoleWithCode.Id != role.Id)
                {
                    return new UpdateRoleResponse { Message = "A role with the same code already exists." };
                }
            }

            role.Code = request.Code;
            role.Name = request.Name;

            await _roleService.UpdateAsync(role);

            return new UpdateRoleResponse { Message = "Role updated successfully." };
        }
    }
}
