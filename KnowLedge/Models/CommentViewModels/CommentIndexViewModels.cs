using Know.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowLedge.Models.CommentViewModels
{
    public class CommentIndexViewModels : CommentEntity
    {
        public List<CommentIndexViewModels> childEntity { get; set; }
    }
}
