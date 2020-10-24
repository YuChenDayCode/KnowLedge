using Know.IRepository.IRepository;
using Know.Model.Entity;
using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Know.Repository.Repository
{
    public class CommentRepository : BaseRepository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(IFreeSql freeSql) : base(freeSql) { }
    }
}
