using GenerateToken.Api.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenerateToken.Entity.JsonOutput;

namespace GenerateToken.Api.Controllers
{
    public class HomeController : Controller
    {
        [AcessAuthorization]
        [HttpPost]
        public ActionResult CreateToken()
        {
            GenerateTokenJsonOutPut generateTokenJson = new GenerateTokenJsonOutPut()
            {
                Token = Guid.NewGuid().ToString(),
                Expires_in = 123123123,
                TokenType = "bcsds_alho",
                Scope = "scope"
            };
            return Json(generateTokenJson);
        }
    }
}
