using Muhasebe.Application.Messaging;

namespace Muhasebe.Application.Features.AppFeatures.AppUserFeatures.Commands.Login
{
    public sealed record LoginCommand(
        string EmailOrUserName,
        string Password
    ) : ICommand<LoginCommandResponse>;
}
