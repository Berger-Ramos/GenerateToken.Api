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
        public static string CreateToken(CreateTokenJsonInput jsonInput)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("asdasd123#123gasdhagsd");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("client_id", jsonInput.Client_id),
                    new Claim("client_secret",jsonInput.Client_secret),
                    new Claim("grant_type",jsonInput.Grant_type),
                    new Claim("scope",jsonInput.Scope)

                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };
                var UnixtimeDate = (DateTimeOffset)tokenDescriptor.Expires;
                Console.WriteLine(UnixtimeDate.ToUnixTimeSeconds().ToString());
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }catch(Exception e)
            {
                return e.Message;
            }
            
        }
    }
}