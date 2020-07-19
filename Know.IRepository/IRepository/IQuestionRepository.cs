using Know.Model.Entity;
using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Know.IRepository.IRepository
{
    public interface IQuestionRepository:  IDbProvider<QuestionEntity>
    {

    }
}
