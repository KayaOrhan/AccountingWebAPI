using Muhasebe.Application.Messaging;

namespace Muhasebe.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public sealed record LoginCommand(
        string EmailOrUserName,
        string Password
    ) : ICommand<LoginCommandResponse>;
}
