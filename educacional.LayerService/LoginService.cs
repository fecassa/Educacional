using educacional.LayerDomain.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace educacional.LayerService
{
    public class LoginService
    {
        private readonly educacional.LayerInfrastructure.AppContext _context;

        public LoginService(educacional.LayerInfrastructure.AppContext context)
        {
            _context = context;
        }

        public Token GetToken (User user)
        {
            Token _token;

            var _query = _context.Users
                       .Where(s => s.UserName == user.UserName && s.Password == user.Password)
                       .FirstOrDefault<User>();

            if (_query != null)
                _token = new Token() { TokenAccess = this.GenerateToken((User)_query) };
            else
                _token = new Token();

            return _token;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())                    
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
