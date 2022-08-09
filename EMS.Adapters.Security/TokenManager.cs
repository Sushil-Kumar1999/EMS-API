using EMS.Core.Application.Domain.Users;
using EMS.Core.Application.Infrastructure.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace EMS.Security.Jwt
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtConfig _jwtConfig;

        public TokenManager(IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _jwtConfig = optionsMonitor.CurrentValue; 
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email), // unique id
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // used by refresh token
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)              
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);

            var serializedToken= jwtHandler.WriteToken(token);

            return serializedToken;
        }
    }
}
