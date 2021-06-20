using GenerateToken.Api.Authentication;
using System;
using System.Web.Mvc;
using GenerateToken.Api.Service;
using System.Configuration;
using GenerateToken.Entity.JsonOutPut;

namespace GenerateToken.Api.Controllers
{
    public class HomeController : Controller
    {
        [AcessAuthorization]
        [HttpPost]
        public ActionResult CreateToken()
        {
            try
            {
                string scope = this.HttpContext.Request.Form.Get("scope");
                GenerateTokenJsonOutPut generateTokenJson = new GenerateTokenJsonOutPut()
                {
                    Token = InternalAutheticationTokenService.CreateToken(scope),
                    Expires_in = 123123123,
                    TokenType = ConfigurationManager.AppSettings.Get("TokenType"),
                    Scope = "scope"
                };


                return Json(generateTokenJson);
            }catch(Exception e)
            {
                this.HttpContext.Response.StatusCode = 400;
                return Json(e.Message);
            }
        }
    }
}
