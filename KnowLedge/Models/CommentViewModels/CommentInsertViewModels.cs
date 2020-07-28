using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowLedge.Models.CommentViewModels
{
    public class CommentInsertViewModels
    {
        public int Pid { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int AnsweId { get; set; }

        public int Consent { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
