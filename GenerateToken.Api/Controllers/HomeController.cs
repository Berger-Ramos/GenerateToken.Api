using GenerateToken.Api.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenerateToken.Entity.JsonOutput;
using GenerateToken.Api.Service;
using GenerateToken.Entity.JsonInput;
using System.Configuration;
using System.Net;

namespace GenerateToken.Api.Controllers
{
    public class HomeController : Controller
    {
        [AcessAuthorization]
        [HttpPost]
        public ActionResult CreateToken(CreateTokenJsonInput jsonInput)
        {
            ActionExecutedContext actionExecutedContext = new ActionExecutedContext();
            try
            {
                GenerateTokenJsonOutPut generateTokenJson = new GenerateTokenJsonOutPut()
                {
                    Token = InternalAutheticationTokenService.CreateToken(jsonInput),
                    Expires_in = 123123123,
                    TokenType = ConfigurationManager.AppSettings.Get("TokenType"),
                    Scope = "scope"
                };
                return Json(generateTokenJson);
            }catch(Exception e)
            {
                
                return Json(e.Message);
            }
        }
    }
}
