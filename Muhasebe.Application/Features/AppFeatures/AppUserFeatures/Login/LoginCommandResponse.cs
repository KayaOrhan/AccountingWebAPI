

namespace Muhasebe.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public record LoginCommandResponse(
        string Email,
        string UserId,
        string NameLastName,
        string Token
    );
}
