using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowLedge.Models.AnswerViewModels
{

    public class AnswerInsertViewModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        public string Content { get; set; }

        public int Consent { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }

  
}
