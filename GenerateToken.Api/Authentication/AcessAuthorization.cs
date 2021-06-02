using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace GenerateToken.Api.Authentication
{
    public class AcessAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            try
            {
                
                throw new Exception();
                if (filterContext.HttpContext.Request.Headers == null)
                    throw new Exception();
                if (filterContext.HttpContext.Request.Form == null)
                    throw new Exception();
            }catch(Exception e)
            {
                filterContext.HttpContext.Response.StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest);
                return;
            }
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
           
        }
    }
}