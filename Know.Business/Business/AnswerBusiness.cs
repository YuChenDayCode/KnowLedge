using Know.IRepository.IRepository;
using Know.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Know.Business.Business
{
    public class AnswerBusiness
    {
        private readonly IAnswerRepository _iAnswerRepository = null;
        public AnswerBusiness(IAnswerRepository iAnswerRepository)
        {
            _iAnswerRepository = iAnswerRepository;
        }

        public IEnumerable<AnswerEntity> GetList(Expression<Func<AnswerEntity, object>> exp)
        {
            return _iAnswerRepository.GetList(exp);
        }

        public bool Insert(AnswerEntity model)
        {

            return _iAnswerRepository.Insert(model);
        }
    }
}
