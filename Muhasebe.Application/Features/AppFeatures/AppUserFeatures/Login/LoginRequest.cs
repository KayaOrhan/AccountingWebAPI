

using MediatR;

namespace Muhasebe.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public sealed class LoginRequest : IRequest<LoginResponse>
    {
        public string EmailOrUserName{ get; set; }
        public string Password{ get; set; }
    }
}
