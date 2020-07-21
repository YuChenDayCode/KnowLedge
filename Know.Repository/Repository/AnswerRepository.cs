using Know.IRepository.IRepository;
using Know.Model.Entity;
using Myn.Data.ORM;

namespace Know.Repository.Repository
{
    public class AnswerRepository : MysqlProvider<AnswerEntity>, IAnswerRepository
    {

    }
}
