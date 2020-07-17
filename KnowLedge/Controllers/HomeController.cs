using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork;
using Know.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KnowLedge.Controllers
{
    public class HomeController : Controller
    {
        public readonly Testbll _Testbll = null;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, Testbll Testbll)
        {
            _Testbll = Testbll;
            _logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //ITest iTest = new Test();

            // ITest it = HttpContext.RequestServices.GetService(typeof(ITest)) as ITest;
            ViewBag.Aa = _Testbll.GetStr("testss");
            for (int i = 0; i < 600; i++)
            {
                _logger.LogDebug("Debug日志");
                _logger.LogError("Error日志");
                _logger.LogInformation("这是一个日志");
            }
           
            return View();
        }

        public IActionResult login()
        {
            string loginUrl = "http://m.tnblog.net/api/v2/Login/cz/123456";
            var oo = HttpHelp.Get(loginUrl);
            return Json(oo);
        }


        public IActionResult Answer()
        {
            return View();
        }
    }
}
