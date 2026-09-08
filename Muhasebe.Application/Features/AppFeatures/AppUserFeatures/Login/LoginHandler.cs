using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Muhasebe.Application.Abstractions;
using Muhasebe.Domain.AppEntities.Identity;

namespace Muhasebe.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;

        public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.Where(p => p.Email == request.EmailOrUserName
            || p.UserName == request.EmailOrUserName).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("User not found.");
            
            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);

            if(!checkUser)
            {
                throw new Exception("Invalid password.");
            }

            List<string> roles = new();

            LoginResponse response = new LoginResponse
            {
                Token = await _jwtProvider.CreateTokenAsync(user, roles),
                Email = user.Email,
                UserId = user.Id,
                NameLastName = user.NameLastName
            };

            return response;
        }
    }
}
