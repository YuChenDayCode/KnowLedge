using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.Filter
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order => throw new NotImplementedException();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }

   
    /// <summary>
    /// 结果过滤器
    /// </summary>
    public class CustomResultFilterAttribute : Attribute, IResultFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order => throw new NotImplementedException();

        /// <summary>
        /// 视图替换完成
        /// </summary>
        /// <param name="context"></param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
