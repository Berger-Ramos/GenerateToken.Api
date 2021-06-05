using GenerateToken.Entity.JsonInput;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace GenerateToken.Api.Service
{
    public class InternalAutheticationTokenService
    {
        public static string CreateToken()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("asdasd123#123gasdhagsd");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                  CompressionAlgorithm = "PS256",
                    TokenType = "at+jwt",
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var UnixtimeDate = (DateTimeOffset)tokenDescriptor.Expires;
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }catch(Exception e)
            {
                return e.Message;
            }
            
        }
    }
}