using GenerateToken.Api.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenerateToken.Entity.JsonOutput;
using GenerateToken.Api.Service;
using GenerateToken.Entity.JsonInput;


namespace GenerateToken.Api.Controllers
{
    public class HomeController : Controller
    {
        [AcessAuthorization]
        [HttpPost]
        public ActionResult CreateToken(CreateTokenJsonInput jsonInput)
        {
            try
            {
                GenerateTokenJsonOutPut generateTokenJson = new GenerateTokenJsonOutPut()
                {
                    Token = InternalAutheticationTokenService.CreateToken(jsonInput),
                    Expires_in = 123123123,
                    TokenType = "bcsds_alho",
                    Scope = "scope"
                };
                return Json(generateTokenJson);
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
