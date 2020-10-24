using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Know.Repository
{
    public interface IBaseRepository<T> where T : new()
    {
        /// <summary>
        /// 
        /// long id = fsql.Insert(blog).ExecuteIdentity();
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Insert(T entity);

        /// <summary>
        /// 
        /// fsql.Insert(items.First()).ExecuteAffrows();
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<T> Insert(List<T> list);

        /// <summary>
        /// 动态条件支持
        /// dywhere 支持 [主键值、new[] { 主键值1, 主键值2  }、Topic对象、new[] { Topic对象1, Topic对象2}、new { id = 1 }]
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        int Update(object dywhere);

        /// <summary>
        /// 指定字段更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="UpdateExpress"></param>
        /// <returns></returns>
        int Update(T entity);// Expression<Func<T, T>> UpdateExpress

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        long Count(Expression<Func<T, bool>> express);

        /// <summary>
        /// 是否有记录
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        bool IsRecord(Expression<Func<T, bool>> express);


        T GetOne(Expression<Func<T, bool>> express);

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> express);

        List<T> GetList(string sql);

        List<T> GetList(Expression<Func<T, bool>> express, Expression<Func<T, object>> orderField, bool IsDesc = true);


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="express"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="orderField"></param>
        /// <param name="IsDesc"></param>
        /// <returns></returns>
        List<T> GetListPage(Expression<Func<T, bool>> express, int PageIndex, int PageSize, out long Count, Expression<Func<T, object>> orderField, bool IsDesc = true);
    }
}
