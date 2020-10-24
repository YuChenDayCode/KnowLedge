using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Know.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected readonly IFreeSql _iFreeSql;
        protected readonly FreeSql.IBaseRepository<T> _baseRepository;
        public BaseRepository(IFreeSql freeSql)
        {
            _iFreeSql = freeSql;
            _baseRepository = freeSql.GetGuidRepository<T>();
        }
        public virtual long Count(Expression<Func<T, bool>> express)
        {
            return _baseRepository.Where(express).Count();

        }

        public T GetOne(Expression<Func<T, bool>> express)
        {
            return _baseRepository.Where(express).ToOne();
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> express)
        {
            return _baseRepository.Where(express).ToList();
        }

        public List<T> GetList(string sql)
        {
            return _iFreeSql.Ado.Query<T>(sql);
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> express, Expression<Func<T, object>> orderField, bool IsAsc = true)
        {
            var list = _baseRepository.Where(express);
            return IsAsc ? list.OrderBy(orderField).ToList() : list.OrderByDescending(orderField).ToList();
        }


        public virtual List<T> GetListPage(Expression<Func<T, bool>> express, int PageIndex, int PageSize, out long Count, Expression<Func<T, object>> orderField, bool IsAsc = true)
        {
            string a = _baseRepository.Where(express).Page(PageIndex, PageSize).Count(out Count).ToSql();
            var list = _baseRepository.Where(express).Page(PageIndex, PageSize).Count(out Count);

            return IsAsc ? list.OrderBy(orderField).ToList() : list.OrderByDescending(orderField).ToList();
        }

        public virtual T Insert(T entity)
        {
            return _baseRepository.Insert(entity);
        }

        public virtual List<T> Insert(List<T> list)
        {
            return _baseRepository.Insert(list);
        }

        public virtual bool IsRecord(Expression<Func<T, bool>> express)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(object dywhere)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(T entity)
        {
            return _baseRepository.Update(entity);
        }

    }
}
