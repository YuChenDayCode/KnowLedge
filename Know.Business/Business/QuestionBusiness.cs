using Know.IRepository.IRepository;
using Know.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Know.Business.Business
{
    public class QuestionBusiness
    {
        private readonly IQuestionRepository _iQuestionRepository = null;
        public QuestionBusiness(IQuestionRepository iQuestionRepository)
        {
            _iQuestionRepository = iQuestionRepository;
        }

        public QuestionEntity Get(Expression<Func<QuestionEntity, object>> exp)
        {
            var ss = _iQuestionRepository.Get(exp);
            return ss;
        }

        public IEnumerable<QuestionEntity> GetList(Expression<Func<QuestionEntity, object>> exp)
        {
            //_iQuestionRepository.Count(t=>t.Id==1,t=>t.Id);
            int count = 0;
            var ss = _iQuestionRepository.GetListPage(exp, 0, 10, out count, s => s.CreateTime, "Desc");
            return ss;
        }
        public bool Insert(QuestionEntity model)
        {
            return _iQuestionRepository.Insert(model);
        }
    }
}
