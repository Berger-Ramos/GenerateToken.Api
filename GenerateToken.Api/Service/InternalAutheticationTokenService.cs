using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GenerateToken.Api.Service
{
    public class InternalAutheticationTokenService
    {
        public static string CreateToken( string algo)
        {
            try
            {
                throw new Exception();
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("asdasd123#123gasdhagsd");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                  CompressionAlgorithm = "PS+.256",
                    TokenType = "at+jwt",
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                           new Claim("scope",algo)
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