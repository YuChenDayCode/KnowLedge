using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Know.Business.Business;
using Know.Model.Entity;
using KnowLedge.Models.AnswerViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnowLedge.Controllers
{
    public class AnswerController : BaseController
    {
        private readonly ILogger<AnswerController> _logger;
        public readonly AnswerBusiness _answerBusiness = null;
        public readonly QuestionBusiness _question = null;
        public AnswerController(ILogger<AnswerController> logger,AnswerBusiness answerBusiness, QuestionBusiness question)
        {
            _logger = logger;
            _answerBusiness = answerBusiness;
            _question = question;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAnswer(int id)
        {
            var questionEntity = _question.Get(t => t.Id == id);
            var answerList = _answerBusiness.GetList(t => t.QuestionId == id);
            return Json(new { questionEntity = questionEntity, answerList = answerList });
        }

        public JsonResult Reply(AnswerInsertViewModel model)
        {
            var entity = new AnswerEntity().EntityParse(model);
            entity.CreateTime = DateTime.Now;
            var issucc = _answerBusiness.Insert(entity);
            if (issucc)
                return JsonMsg(issucc, "成功");
            return JsonMsg(false, "失败");
        }
    }
}