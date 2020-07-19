using System;
using System.Collections.Generic;
using System.Text;
using Know.IRepository.IRepository;
using Know.Model.Entity;
using Myn.Data.ORM;

namespace Know.Repository.Repository
{
    public class QuestionRepository : MysqlProvider<QuestionEntity>, IQuestionRepository
    {

      
    }
}
