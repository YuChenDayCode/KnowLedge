using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KnowLedge.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult CreateResponseMessage(bool status, string message, object data, int count = 0)
        {
            var Value = new { Status = status, Msg = message, Data = data, Count = count };
            return new CustomJsonResult(Value);
        }

        protected JsonResult JsonMsg(bool status, string msg="", object data = null)
        {

            return CreateResponseMessage(status, msg, data);
        }


    }


    public class CustomJsonResult : JsonResult
    {
        public CustomJsonResult(object value) : base(value) { }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("返回内容不能为空");
            }

            context.HttpContext.Response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (Value != null)
            {
                await context.HttpContext.Response.Body.WriteAsync(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Value)));
            }
        }
    }
}