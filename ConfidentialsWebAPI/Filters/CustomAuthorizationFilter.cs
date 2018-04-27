using ConfidentialsWebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ConfidentialsWebAPI.Filters
{
    public class CustomAuthorizationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string dataToEncrypt = string.Format("{0}\n{1}\n{2}", context.HttpContext.Request.Method, context.HttpContext.Request.ContentType.Split(';')[0], string.Format("{0:MM/dd/yyyy}", DateTime.Now));
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];
             if (!authorizationHeader.Equals(EncryptionHelper.Encrypt(dataToEncrypt)))
                context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }

}
