using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IOC
{
    public class IOCContainer : IIOCContainer
    {
        private static Dictionary<string, Type> keyValues = new Dictionary<string, Type>();

        public void Register<K, T>() where T : K
        {
            keyValues.Add(typeof(K).FullName, typeof(T));
        }

        public T Resolve<T>()
        {
         return  (T)ResolveObject(typeof(T));

        }

        private object ResolveObject(Type obj)
        {
            string key = obj.FullName;
            Type type = keyValues[key];

            var constructor = type.GetConstructors()[0];

            List<object> pList = new List<object>();
            foreach (var para in constructor.GetParameters())
            {
                Type ParaType = para.ParameterType;
                var paraObj = ResolveObject(ParaType);
                pList.Add(paraObj);
            }
            object objInt = Activator.CreateInstance(type,pList.ToArray());
            return objInt;
        }
    }
}
