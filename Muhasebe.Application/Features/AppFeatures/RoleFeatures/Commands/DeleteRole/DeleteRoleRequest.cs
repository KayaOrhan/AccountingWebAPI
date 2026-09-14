using MediatR;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed class DeleteRoleRequest : IRequest<DeleteRoleResponse>
    {
        public string Id { get; set; }
    }
}
