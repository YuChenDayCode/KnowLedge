using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Know.Business.Business;
using Know.Model.Entity;
using KnowLedge.Models.CommentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core;

namespace KnowLedge.Controllers
{
    public class CommentController : BaseController
    {
        public readonly CommentBusiness _iCommentBusiness = null;

        private readonly ILogger<CommentController> _logger;
        public CommentController(ILogger<CommentController> logger, CommentBusiness CommentBusiness)
        {
            _logger = logger;
            _iCommentBusiness = CommentBusiness;

        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetCommentByAid(int aid)
        {
            List<CommentEntity> list = _iCommentBusiness.GetList(t => t.AnsweId == aid).ToList();

            List<CommentIndexViewModels> viewmodel = new List<CommentIndexViewModels>();
            Generate(list, list.Where(t => t.Pid == 0).ToList(), viewmodel);
            return JsonMsg(true, "", viewmodel);
        }
        public void Generate(List<CommentEntity> list, List<CommentEntity> plist, List<CommentIndexViewModels> viewmodel)
        {
            foreach (var item in plist)
            {
                var mdoel = new CommentIndexViewModels().EntityParse(item);
                var viewlist = list.Where(t => t.Pid == item.Id);
                var cm = new List<CommentIndexViewModels>();
                foreach (var citem in viewlist)
                {
                    var e = new CommentIndexViewModels().EntityParse(citem);
                    cm.Add(e);
                    var cc = list.Where(t => t.Pid == e.Id).ToList();
                    if (cc.Count() > 0)
                        Generate(list, cc, viewmodel);
                }
                mdoel.childEntity = cm;
                viewmodel.Add(mdoel);
            }




        }

    }
}