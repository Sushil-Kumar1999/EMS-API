using EMS.Core.Application.Domain.Users;
using EMS.Core.Application.Infrastructure.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace EMS.Security.Jwt
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtConfig _jwtConfig;
        private readonly UserManager<ApplicationUser> _userManager;

        public TokenManager(IOptionsMonitor<JwtConfig> optionsMonitor, UserManager<ApplicationUser> userManager)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var claims = await GetClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)              
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);

            var serializedToken= jwtHandler.WriteToken(token);

            return serializedToken;
        }

        private async Task<IEnumerable<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email), // unique id
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // used by refresh token
            };
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            claims.AddRange(roleClaims);

            return claims;
        }
    }
}
