using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace GenerateToken.Api.Authentication
{
    public class AcessAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            try
            {
                if(actionContext.Request.Headers.Authorization == null)
                    throw new Exception();
            }catch(Exception e)
            {
                actionContext.Response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
        }
    }
}