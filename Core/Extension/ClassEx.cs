using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class ClassEx
    {
        /// <summary>
        /// 实体转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">目标实体</param>
        /// <param name="source">源实体</param>
        /// <returns></returns>
        public static T EntityParse<T, K>(this T target, K source) where T : class where K : class
        {
            if (source != default(K))
            {
                var pros = typeof(T).GetProperties();
                var spros = typeof(K).GetProperties();
                var dic = (from t in spros select new KeyValuePair<string, object>(t.Name, t.GetValue(source, null))).ToDictionary(m => m.Key, m => m.Value);

                foreach (var p in pros)
                {
                    if (dic.ContainsKey(p.Name))
                    {
                        p.SetValue(target, dic[p.Name], null);
                    }
                }
            }

            return target;
        }
    }
}
