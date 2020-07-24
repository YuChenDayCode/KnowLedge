using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.MiddleWare
{
    /*当委托不将请求传递给下一个委托时，它被称为“让请求管道短路”。 通常需要短路，因为这样可以避免不必要的工作。 
     * 例如，静态文件中间件可以处理对静态文件的请求，并让管道的其余部分短路，从而起到终端中间件的作用。
     * 如果中间件添加到管道中，且位于终止进一步处理的中间件前，它们仍处理 next.Invoke 语句后面的代码。 不过，请参阅下面有关尝试对已发送的响应执行写入操作的警告。*/
    /// <summary>
    /// 防盗链
    /// </summary>
    public class ContactMiddleware
    {
        private readonly RequestDelegate _next;
        public ContactMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string url = context.Request.Path.Value;
            if (url.Contains(".jpg") || url.Contains(".jpeg") || url.Contains(".png"))
            {
                string Referer = context.Request.Headers["Referer"];
                if (string.IsNullOrWhiteSpace(Referer))
                {
                    await SetForbiddenImage(context);
                }
                else if (!Referer.Contains("localhost"))//非当前域名
                {
                    await SetForbiddenImage(context);
                }
            }
            await _next(context);
        }

        public async Task SetForbiddenImage(HttpContext context)
        {
            string defaultImgPath = "wwwroot/404.png";
            string path = Path.Combine(Directory.GetCurrentDirectory(), defaultImgPath);
            await context.Response.SendFileAsync(path);

            /*
              FileStream fs = File.OpenRead(path);
              byte[] bytes = new byte[fs.Length];
              await fs.ReadAsync(bytes, 0, bytes.Length);
              await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);*/

        }

    }
}
