using Muhasebe.Application.Messaging;

namespace Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed record CreateRoleCommand(string Name, string Code) : ICommand<CreateRoleCommandResponse>;
}
