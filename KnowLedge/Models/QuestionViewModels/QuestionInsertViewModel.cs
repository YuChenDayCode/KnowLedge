using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowLedge.Models.QuestionViewModels
{
    public class QuestionInsertViewModel
    {
        public int Id { get; set; }

        public string _Tag;
        public string Tag { 
            get { return _Tag; } 
            set { _Tag = value.Replace(" ", "").Replace("，", ","); } 
        }

        public string Desc { get; set; }

        public string Title { get; set; }

        public int Views { get; set; }

        public string AskuserId { get; set; }

        public DateTime? CreateTime { get; set; }

    }
}
