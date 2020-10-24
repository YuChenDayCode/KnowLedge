using Core.IOC;
using Know.IRepository.IRepository;
using Know.Model.Entity;
using Know.Repository.Repository;
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

        public QuestionEntity Get(Expression<Func<QuestionEntity, bool>> exp)
        {
            var ss = _iQuestionRepository.GetOne(exp);
            return ss;
        }

        public IEnumerable<QuestionEntity> GetList(Expression<Func<QuestionEntity, bool>> exp)
        {
            /* IIOCContainer container = new IOCContainer();
             container.Register<IQuestionRepository, QuestionRepository>();

             var a = container.Resolve<IQuestionRepository>();

             */

            //_iQuestionRepository.Count(t=>t.Id==1,t=>t.Id);
            long count = 0;
            var ss = _iQuestionRepository.GetListPage(exp, 0, 10, out count, s => s.CreateTime, true);
            return ss;
        }
        public QuestionEntity Insert(QuestionEntity model)
        {
            return _iQuestionRepository.Insert(model);
        }

        public IEnumerable<QuestionEntity> GetTag(string sql)
        {
            var list = _iQuestionRepository.GetList(sql);
            return list;
        }
    }
}
