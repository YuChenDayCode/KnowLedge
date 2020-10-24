using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IOC
{
    public  interface IIOCContainer
    {
        public void Register<K, T>() where T : K;

        public T Resolve<T>();
    }
}
