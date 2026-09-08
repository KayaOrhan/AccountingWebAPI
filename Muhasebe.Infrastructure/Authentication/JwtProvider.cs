using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Muhasebe.Application.Abstractions;
using Muhasebe.Domain.AppEntities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Muhasebe.Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<string> CreateTokenAsync(AppUser user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.NameLastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, String.Join(",", roles))
            };
            JwtSecurityToken jwtSecurityToken = new(
                issuer : _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims : claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                    algorithm: SecurityAlgorithms.HmacSha256
                )
            );
            string token =  new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            
            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = DateTime.Now.AddDays(1);
            
            await _userManager.UpdateAsync(user);
            return token;

        }
    }
}
