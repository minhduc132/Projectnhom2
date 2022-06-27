using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServerApi
{
    public class Auth : IAuth
    {
        public string key;
        public Auth(string key)
        {
            this.key = key;
        }
        public string Authentication(string username, string password)
        {//1: tao obj security
            //var tokenHandler = new JwtSecurityTokenHandler();
            ////2: tao private key to encrypted
            //var tokenKey = Encoding.ASCII.GetBytes(key);
            ////3:Tao JETdescriptor
            //var tokenDescriptor = new SecurityTokenDescriptor()
            //{
            //    Subject = new ClaimsIdentity(
            //        new Claim[]
            //        {
            //            new Claim(ClaimTypes.Name, username)
            //        }),
            //    Expires = DateTime.UtcNow.AddHours(1),
            //    SigningCredentials = new SigningCredentials
            //    (new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            //};
            ////4: Tao token
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            ////5: tra ve token form method
            //return tokenHandler.WriteToken(token);

            var issuer = "SomeIssuer";
            var audience = "SomeAudience";
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
