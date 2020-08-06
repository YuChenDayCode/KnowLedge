using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace Core.Utility.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _ilogger;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _ilogger = logger;
        }


        /// <summary>
        /// 异常发生时触发
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                Console.WriteLine($"{context.HttpContext.Request.Path} {context.Exception.Message}");
                string isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest" ? "Ajax" : "";

                StringBuilder para = new StringBuilder();
                foreach (ParameterDescriptor item in context.ActionDescriptor.Parameters)
                {
                    if (item.ParameterType.IsClass)
                    {
                        string kv = GetModelStateString(context.ModelState);
                        para.AppendLine($"[ Name:{item.Name},Value:{kv},Type:{item.ParameterType.Name} ]");
                    }
                    else
                        para.AppendLine($"[ Name:{item.Name},Value:{context.HttpContext.Request.Query[item.Name]},Type:{item.ParameterType.Name} ]");
                }

                _ilogger.LogError($" RequestPath: {context.HttpContext.Request.Path}\n" +
                    $" RequestType: {context.HttpContext.Request.Method} {isAjaxCall}\n" +
                    $" Parameters: {para.ToString()}" +
                    $" Message: {context.Exception.Message}\n" +
                    $" Detail:{context.Exception.StackTrace}");

                context.ExceptionHandled = true; //异常不在抛出
            }

        }
        public string GetModelStateString(ModelStateDictionary valuePairs)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (string key in valuePairs.Keys)
            {
                dic.Add(key, valuePairs[key].RawValue);
                sb.Append($"{key.Split('.')?[1]}:{valuePairs[key].RawValue},");
            }
            return $"{{{sb.ToString().TrimEnd(',')}}}";
        }
    }

}
