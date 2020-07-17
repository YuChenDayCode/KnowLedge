using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 异常发生时触发
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                Console.WriteLine($"{context.HttpContext.Request.Path} {context.Exception.Message}");
                context.Result = new JsonResult(new
                {
                    result = false,
                    Msg = "异常"
                });
                context.ExceptionHandled = true;
            }

        }
    }
}
