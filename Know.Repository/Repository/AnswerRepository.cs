using Know.IRepository.IRepository;
using Know.Model.Entity;
using Myn.Data.ORM;

namespace Know.Repository.Repository
{
    public class AnswerRepository : BaseRepository<AnswerEntity>, IAnswerRepository
    {
        public AnswerRepository(IFreeSql freeSql) : base(freeSql)
        {

        }
    }
}
