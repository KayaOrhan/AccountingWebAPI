using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Muhasebe.Application.Abstractions;
using Muhasebe.Application.Messaging;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.AppUserFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;

        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.Where(p => p.Email == request.EmailOrUserName
            || p.UserName == request.EmailOrUserName).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("User not found.");
            
            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);

            if(!checkUser)
            {
                throw new Exception("Invalid password.");
            }

            List<string> roles = new();

            LoginCommandResponse response = new(
                user.Email,
                user.Id,
                user.NameLastName,
                await _jwtProvider.CreateTokenAsync(user, roles)
            );

            return response;
        }
    }
}
