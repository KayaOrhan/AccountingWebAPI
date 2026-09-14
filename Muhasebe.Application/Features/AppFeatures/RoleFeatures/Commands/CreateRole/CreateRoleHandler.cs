using MediatR;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
       private readonly IRoleService _roleService;

        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetByCode(request.Code);

            if (role is not null)
            {
                return new CreateRoleResponse
                {
                    Message = "Role already exists."
                };
            }

            await _roleService.AddAsync(request);

            return new CreateRoleResponse
            {
                Message = "Role created successfully."
            };
        }
    }
}
