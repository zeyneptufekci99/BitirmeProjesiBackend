using BitirmeProjesiBackend.Application.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BitirmeProjesiBackend
{
    public class TokenGenerator
    {
        public TokenResponse GenerateJwt(UserDto userDto)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key));
            SigningCredentials credentials = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role,userDto.RoleDefinition));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,userDto.Id.ToString()));
            claims.Add(new Claim("username", userDto.Username));
            claims.Add(new Claim("name", userDto.Name));
            claims.Add(new Claim("roleId", userDto.RoleDefinition));
            claims.Add(new Claim("userId", userDto.Id.ToString()));
            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtInfo.Issuer
                ,audience:JwtInfo.Audience,claims :claims, notBefore:DateTime.UtcNow, expires:DateTime.UtcNow.AddDays(15),signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponse( handler.WriteToken(token));
        }
       
    }
}
