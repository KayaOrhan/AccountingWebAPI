
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user, List<string> roles);
    }
}
