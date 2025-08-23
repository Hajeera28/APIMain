using APIMainProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using APIMainProject.Interface;
using System.Text;

namespace APIMainProject.Services
{
    public class TokenService : IToken
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration)
        {
            _key = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]!));
        }
        public string GenerateToken(User user)
        {
            string token = string.Empty;
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.NameId,user.UserName!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Role, user.Role ?? "User")
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescription);
            token = tokenHandler.WriteToken(myToken);
            return token;
        }
    }


}
