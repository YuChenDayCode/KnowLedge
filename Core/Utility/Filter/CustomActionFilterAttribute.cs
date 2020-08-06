using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.Filter
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter, IFilterMetadata, IOrderedFilter
    {
        private readonly ILogger<CustomActionFilterAttribute> _ilogger;
        public CustomActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            _ilogger = logger;
        }
        public int Order => throw new NotImplementedException();

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest" ? "Ajax" : "";

            StringBuilder para = new StringBuilder();
            foreach (KeyValuePair<string, object> item in context.ActionArguments)
            {
                para.Append($"{{ Name:{item.Key},Value:{JsonConvert.SerializeObject(item.Value)},Type:{item.Value.GetType().Name} }}\n");
            }
            _ilogger.LogInformation($" RequestPath: {context.HttpContext.Request.Path}\n" +
                $" RequestType: {context.HttpContext.Request.Method} {isAjaxCall}\n" +
                $" Parameters: {para.ToString().TrimEnd('\n')}");
        }
    }
}
