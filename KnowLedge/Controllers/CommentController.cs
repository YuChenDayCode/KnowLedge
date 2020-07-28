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
            viewmodel = Generate(list, list.Where(t => t.Pid == 0).ToList());
            return JsonMsg(true, "", viewmodel);
        }

        public List<CommentIndexViewModels> Generate(List<CommentEntity> list, List<CommentEntity> plist)
        {
            List<CommentIndexViewModels> lvm = new List<CommentIndexViewModels>();

            foreach (var item in plist)
            {
                var mdoels = new CommentIndexViewModels().EntityParse(item);
                List<CommentIndexViewModels> l = new List<CommentIndexViewModels>();
                childcomment(list, item, l);
                mdoels.childEntity = l.OrderBy(o => o.CreateTime).ToList();
                lvm.Add(mdoels);
            }
            return lvm.OrderBy(o => o.Id).ThenBy(o => o.CreateTime).ToList();
        }

        public void childcomment(List<CommentEntity> list, CommentEntity model, List<CommentIndexViewModels> lvm)
        {
            var l = list.Where(t => t.Pid == model.Id).ToList();

            foreach (var item in l)
            {
                var mdoels = new CommentIndexViewModels().EntityParse(item);
                var a = list.Where(t => t.Pid == item.Id);
                if (a.Count() > 0)
                {
                    childcomment(list, item, lvm);
                }
                lvm.Add(mdoels);
            }

        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="list"></param>
        /// <param name="plist"></param>
        /// <returns></returns>
        public List<CommentIndexViewModels> Generate_del(List<CommentEntity> list, List<CommentEntity> plist)
        {
            List<CommentIndexViewModels> lvm = new List<CommentIndexViewModels>();
            foreach (var item in plist)
            {
                var mdoel = new CommentIndexViewModels().EntityParse(item);
                var viewlist = list.Where(t => t.Pid == item.Id);
                var cm = new List<CommentIndexViewModels>();
                foreach (var citem in viewlist)
                {
                    var e = new CommentIndexViewModels().EntityParse(citem);
                    var cc = list.Where(t => t.Pid == e.Id).ToList();
                    if (cc.Count() > 0)
                    {
                        List<CommentIndexViewModels> temp = Generate(list, cc);
                        e.childEntity = temp;
                    }
                    cm.Add(e);
                    mdoel.childEntity = cm;
                }
                lvm.Add(mdoel);
            }
            return lvm;
        }

        public IActionResult AddCommentReply(CommentInsertViewModels viewmodel)
        {
            var model = new CommentEntity().EntityParse(viewmodel);
            model.CreateTime = DateTime.Now;
            var issucc = _iCommentBusiness.Insert(model);
            if (issucc)
            {
                var count = _iCommentBusiness.CommentCountByAnswerId(model.AnsweId);
                return JsonMsg(issucc,"", count);
            }
            return JsonMsg(false,"评论失败,请检查");
        }

    }
}