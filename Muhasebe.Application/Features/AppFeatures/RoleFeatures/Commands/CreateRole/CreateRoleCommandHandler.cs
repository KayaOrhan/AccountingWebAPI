using Muhasebe.Application.Messaging;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
       private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetByCode(request.Code);

            if (role is not null)
            {
                return new CreateRoleCommandResponse
                {
                    Message = "Role already exists."
                };
            }

            await _roleService.AddAsync(request);

            return new CreateRoleCommandResponse
            {
                Message = "Role created successfully."
            };
        }
    }
}
