using System;
using System.Collections.Generic;
using System.Text;
using Know.IRepository.IRepository;
using Know.Model.Entity;
using Myn.Data.ORM;

namespace Know.Repository.Repository
{
    public class QuestionRepository : BaseRepository<QuestionEntity>, IQuestionRepository
    {
        public QuestionRepository(IFreeSql freeSql) : base(freeSql)
        {
           
        }
        public List<QuestionEntity> QueryByTag()
        {
            return _iFreeSql.Ado.Query<QuestionEntity>("select * from ");
        }
    }
}
