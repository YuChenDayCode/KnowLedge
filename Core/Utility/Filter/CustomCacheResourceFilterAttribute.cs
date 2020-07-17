using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.Filter
{
    /// <summary>
    /// 资源过滤器 一般用作缓存
    /// </summary>
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata, IOrderedFilter
    {

        /// IOrderedFilter 排序

        private static Dictionary<string, object> Cache = new Dictionary<string, object>();

        public int Order => 0;

        /// <summary>
        /// 控制器实例化之前执行 避免实例化 与action的执行，但是view会重新执行
        /// </summary>
        /// <param name="context"></param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //使用缓存
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
           //存储缓存
        }

       
    }
}
