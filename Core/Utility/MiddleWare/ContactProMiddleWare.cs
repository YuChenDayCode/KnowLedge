using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.MiddleWare
{
    /// <summary>
    /// 防盗链
    /// </summary>
    public class ContactProMiddleWare
    {
        private readonly RequestDelegate _next;
        public ContactProMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string url = context.Request.Path.Value;
            if ((!url.Contains(".jpg")) || (!url.Contains(".png")))
            {
                await _next(context);
            }

            string referer = context.Request.Headers["Referer"];
            if (string.IsNullOrWhiteSpace(referer))
            {
                await SetForbiddenImage(context);
            }
            else if (!referer.Contains("当前域名"))//非当前域名
            {
                await SetForbiddenImage(context);
            }
        }

        public async Task SetForbiddenImage(HttpContext context)
        {
            string defaultImgPath = "";
            string path = Path.Combine(Directory.GetCurrentDirectory(), defaultImgPath);

            FileStream fs = File.OpenRead(path);
            byte[] bytes = new byte[fs.Length];
            await fs.ReadAsync(bytes, 0, bytes.Length);
            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }

    }
}
