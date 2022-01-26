using Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Auth
{
    public class TokenHandler
    {
        //token expiry time
        private const double Jwt_Expiry = 2;

        //class that generate the token
        //we can use user object properties if we want
        public static string GenerateToken(string key, string issuer, User user)
        {
            var claims = new[]
            {
                new Claim("Username", user.Username),
                new Claim("UserId", user.Id.ToString()),

                //random area for additional info
                new Claim("Identifier", Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(issuer, claims: claims, expires: DateTime.Now.AddMinutes(Jwt_Expiry), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
