using Know.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowLedge.Models.AnswerViewModels
{
    public class AnswerIndexViewModel
    {

        public QuestionEntity questionEntity { get; set; }
        public IEnumerable<AnswerEntity> answerList { get; set; }

    }
}
