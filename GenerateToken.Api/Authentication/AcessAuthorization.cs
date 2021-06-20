using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using GenerateToken.Util;

namespace GenerateToken.Api.Authentication
{
    public class AcessAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string client_id = filterContext.HttpContext.Request.Params.Get("client_id");
                string client_secret = filterContext.HttpContext.Request.Params.Get("client_secret");
                string grant_type = filterContext.HttpContext.Request.Params.Get("grant_type");
                string scope = filterContext.HttpContext.Request.Params.Get("scope");

                string[] credencials = { client_id, client_secret, grant_type, scope };
                CheckCredencials(credencials);
                   
            }
            catch (Exception e)
            {
                filterContext.HttpContext.Response.StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest);
                filterContext.Result = new JsonResult() { Data = new { succes = "false", message = e.Message } };
                return;
            }
            base.OnActionExecuting(filterContext);
        }
        
        private static bool CheckCredencials(string[] credencials)
        {
            if (credencials[0]== null)
                throw new Exception(GenerateTokenExceptions.EX0001);
            return true;
           
        }
    }
}