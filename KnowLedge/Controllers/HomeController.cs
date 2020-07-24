using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork;
using Know.Business;
using Know.Business.Business;
using Know.Model.Entity;
using KnowLedge.Models.AnswerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core;
using System.Net;
using KnowLedge.Models.QuestionViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KnowLedge.Controllers
{
    public class HomeController : BaseController
    {
        public readonly Testbll _Testbll = null;
        public readonly QuestionBusiness _question = null;

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, Testbll Testbll, QuestionBusiness question)
        {
            _Testbll = Testbll;
            _logger = logger;
            _question = question;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            //_logger.LogDebug("Debug日志");
            //_logger.LogError("Error日志");
            //_logger.LogInformation("这是一个日志");

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }



        public JsonResult GetQuestion()
        {
            var a = _question.GetList(null);
            return Json(a);
        }
        

        public JsonResult Ask(QuestionInsertViewModel model)
        {
            var entity = new QuestionEntity().EntityParse(model);
            entity.CreateTime = DateTime.Now;
            bool issuu = _question.Insert(entity);
            return JsonMsg(issuu, "");
        }


        public IActionResult login()
        {
            string loginUrl = "http://m.tnblog.net/api/v2/Login/cz/123456";
            var oo = HttpHelp.Get(loginUrl);
            return Json(oo);
        }

    }
}
