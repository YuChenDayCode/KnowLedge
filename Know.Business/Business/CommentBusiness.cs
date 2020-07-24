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
    }
}
