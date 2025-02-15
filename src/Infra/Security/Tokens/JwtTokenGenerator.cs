using Domain.Entities;
using Domain.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infra.Security.Tokens
{
    public class JwtTokenGenerator(
        uint expirationTimeMinutes,
        string signinKey) : IAccessTokenGenerator
    {
        public string Generate(User user)
        {
            IEnumerable<Claim> payloads =
            [
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            ];

            SecurityTokenDescriptor tokenDescription = new()
            {
                SigningCredentials =
                    new SigningCredentials(GetSecurityKey(),
                        SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddMinutes(expirationTimeMinutes),
                Subject = new ClaimsIdentity(payloads)
            };

            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken? securityToken =
                tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(securityToken);
        }


        private SymmetricSecurityKey GetSecurityKey()
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(signinKey);

            return new SymmetricSecurityKey(keyBytes);
        }
    }
}
