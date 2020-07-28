using Myn.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Myn.Data.ORM
{
    public class MysqlQuery<T> : Query<T>
    {
        private int _top = -1;
        public override Query<T> Top(int num)
        {
            this._top = num;
            return this;
        }

        public override ISqlDocker CustomSql(string sql)
        {
            ISqlDocker q = new SqlDocker() { Sql = sql, CommandType = CommandType.Text, Parameters = null };
            return q;
        }


        public override ISqlDocker Build()
        {
            var sql = new StringBuilder();
            if (_sqlCount != null) sql.Append(_sqlCount.CountSql);
            else sql.Append($"SELECT {string.Join(",", from t in this.propertyMaps select t.GetQueryField())} FROM {this.entitymap.TabelName}");

            if (_where != null)
            {
                sql.Append($" WHERE {_where.ToString()} ");
            }
            if (_sqlPaging != null)
            {
                this._top = -1;
                sql.Append(_sqlPaging.PagingSql);
            }
            var topStr = this._top > -1 ? $" LIMIT { this._top }" : string.Empty;
            sql.Append(topStr);


            var docker = new SqlDocker() { Sql = sql.ToString(), CommandType = CommandType.Text };
            if (_where != null)
            {
                var dic = new Dictionary<string, object>();
                _where.GetDictionary(dic);
                docker.Parameters = dic;
            }
            return docker;
        }

        public override Query<T> where(Expression<Func<T, object>> expression)
        {
            this._where = expression == null ? null : Where.Parse(expression, this.propertyMaps);
            return this;
        }

        public override Query<T> Count(Expression<Func<T, object>> field = null)
        {
            string CountKey = "";
            if (field == null)
            {
                CountKey = this.propertyMaps.First(m => m.PrimaryKey != null).ColumnName;
            }
            else
            {
                var property = ReflectionExtension.GetProperty(field);
                CountKey = property.GetCustomAttribute<EntityMapper_ColumnName>()?.AliasName ?? property.Name;
            }
            string sql = $"SELECT COUNT({ this.entitymap.TabelName}.{CountKey}) FROM {this.entitymap.TabelName}";
            _sqlCount = new SqlCount(sql);
            return this;

        }

        public override Query<T> Sort(Expression<Func<T, object>> sort_field, string sortWay = " Asc ")
        {
            //SqlSort ss = new SqlSort() { Sort_Field = ReflectionExtension.GetProperty(sort_field).Name, SortWay = sortWay };
            return this;
        }
        public override Query<T> Paging(int pageIndex, int pageSize, Expression<Func<T, object>> sort_field = null, string sortWay = null, Expression<Func<T, object>> sort_field1 = null, string sortWay1 = null)
        {
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            var PagingSql = new StringBuilder();
            string sort_str = "";
            if (sort_field != null)
            {
                var property = ReflectionExtension.GetProperty(sort_field);
                sort_str = $" ORDER BY {property.GetCustomAttribute<EntityMapper_ColumnName>()?.AliasName ?? property.Name} {sortWay}";
                PagingSql.Append(sort_str);
            }
            if (sort_field1 != null)
            {
                var property1 = ReflectionExtension.GetProperty(sort_field1);
                sort_str = $" ,{property1.GetCustomAttribute<EntityMapper_ColumnName>()?.AliasName ?? property1.Name} {sortWay1}";
                PagingSql.Append(sort_str);
            }

            PagingSql.Append($" LIMIT { (pageIndex - 1) * pageSize},{pageSize}");

            _sqlPaging = new SqlPaging(PagingSql.ToString());
            return this;
        }

    }


}
