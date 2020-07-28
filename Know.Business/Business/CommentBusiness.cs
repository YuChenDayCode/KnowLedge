using Know.IRepository.IRepository;
using Know.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Know.Business.Business
{
    public class CommentBusiness
    {
        private readonly ICommentRepository _iCommentRepository = null;
        public CommentBusiness(ICommentRepository iCommentRepository)
        {
            _iCommentRepository = iCommentRepository;
        }
        public IEnumerable<CommentEntity> GetList(Expression<Func<CommentEntity, object>> exp)
        {
            return _iCommentRepository.GetList(exp);
        }

        public bool Insert(CommentEntity model)
        {

            return _iCommentRepository.Insert(model);
        }

        /// <summary>
        /// 查询某个答案有多少评论
        /// </summary>
        /// <param name="answer_id"></param>
        /// <returns></returns>
        public int CommentCountByAnswerId(int answer_id)
        {

            return _iCommentRepository.Count(c=>c.AnsweId == answer_id);
        }
    }
}
