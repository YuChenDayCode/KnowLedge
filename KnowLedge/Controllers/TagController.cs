using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Know.Business.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnowLedge.Controllers
{
    public class TagController : Controller
    {
        string Id;

        public readonly QuestionBusiness _question = null;
        private readonly ILogger<TagController> _logger;
        public TagController(ILogger<TagController> logger, QuestionBusiness question)
        {
            _logger = logger;
            _question = question;

        }
        public IActionResult Index(string id)
        {
            Id = id;
            return View();
        }

        public JsonResult GetQuestionByTag()
        {
            string s = Id;
            var ss = _question.GetList(t => t.Tag.Contains(s));
            return Json(ss);
        }
    }
}