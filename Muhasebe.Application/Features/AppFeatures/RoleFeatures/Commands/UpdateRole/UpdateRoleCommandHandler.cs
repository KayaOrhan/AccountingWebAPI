using Muhasebe.Application.Messaging;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);

            if (role == null)
            {
                return new UpdateRoleCommandResponse { Message = "Role not found." };
            }

            if (role.Code == request.Code && role.Name == request.Name)
            {
                return new UpdateRoleCommandResponse { Message = "No changes detected." };
            }

            if (role.Code != request.Code)
            {
                AppRole existingRoleWithCode = await _roleService.GetByCode(request.Code);
                if (existingRoleWithCode != null && existingRoleWithCode.Id != role.Id)
                {
                    return new UpdateRoleCommandResponse { Message = "A role with the same code already exists." };
                }
            }

            role.Code = request.Code;
            role.Name = request.Name;

            await _roleService.UpdateAsync(role);

            return new UpdateRoleCommandResponse { Message = "Role updated successfully." };
        }
    }
}
