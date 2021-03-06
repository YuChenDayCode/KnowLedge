﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace Myn.Data.ORM
{
    /// <summary>
    /// Mysql sql 构造
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlServerConstructor<T> : Constructor<T>
    {
        protected override string BuildInsert(IEnumerable<IPropertyMap> propertys)
        {
            //过滤了为null的数据
            var kv = (from t in propertys where t.PropertyInfo.GetValue(this.entity) != null select new KeyValuePair<string, string>(t.GetParamName(), t.Name)).ToDictionary(k => k.Key, v => v.Value);
            return $"({ string.Join(",", kv.Values)}) VALUES ({ string.Join(",", kv.Keys) })";
        }
        protected override string BuildBatchInsert(IEnumerable<IPropertyMap> propertys)
        {
            StringBuilder batch = new StringBuilder();
            batch.Append("begin ");
            int c = 0;
            foreach (var item in this.list)
            {
                c++;
                var kv = (from t in propertys
                          where t.PropertyInfo.GetValue(item) != null
                          select new KeyValuePair<string, string>(t.GetManyParamName(c.ToString()), t.Name)).ToDictionary(k => k.Key, v => v.Value);

                batch.Append(this._DMLType.ToString());
                batch.Append(this.entitymap.TabelName.Fill());
                batch.Append($"({ string.Join(",", kv.Values)}) VALUES ({ string.Join(",", kv.Keys) })\n");
            }
            batch.Append("end; ");
            string a = batch.ToString();
            return a;
        }
        protected override string BuildInsert_Return_Id(IEnumerable<IPropertyMap> propertys)
        {

            string insert_sql = BuildInsert(propertys);
            return $"{insert_sql};SELECT  @@IDENTITY;";
        }


        protected override string BuildUpdate(IEnumerable<IPropertyMap> propertys)
        {
            var u = from t in propertys where t.PropertyInfo.GetValue(this.entity) != null select $"{t.Name}={t.GetParamName()}";
            return $" SET {string.Join(",", u)}";
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetParameter()
        {
            var para = new Dictionary<string, object>();
            if (_where != null)
            {
                string str = _where.ToString();
                var dic = new Dictionary<string, object>();
                _where.GetDictionary(dic);
                foreach (var item in dic)
                {
                    if (!para.ContainsKey(item.Key))
                    {
                        para.Add(item.Key, item.Value);
                    }
                }
            }

            if (this.entity != null)
            {
                foreach (var item in this.property)
                {
                    if (!para.ContainsKey(item.GetParamName()))
                    {
                        var value = item.PropertyInfo.GetValue(this.entity);
                        para.Add(item.GetParamName(), (value == null ? DBNull.Value : value));
                    }
                }
            }
            if (this.list?.Count() > 0)
            {
                int c = 0;
                foreach (var entity in this.list)
                {
                    c++;
                    foreach (var item in this.property)
                    {
                        string ParaName = item.GetManyParamName(c + "");
                        if (!para.ContainsKey(ParaName))
                        {
                            var value = item.PropertyInfo.GetValue(entity);
                            para.Add(ParaName, (value == null ? DBNull.Value : value));
                        }
                    }
                }
            }
            return para;
        }
    }
}
