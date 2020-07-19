using Know.IRepository;
using Know.IRepository.IRepository;
using System;

namespace Know.Business
{
    public class Testbll
    {
        public readonly ITest _iTest = null;
        public Testbll(ITest itest)
        {
            _iTest = itest;
        }
        public string GetStr(string pp)
        {
            return _iTest.GetStr(pp);
        }
    }
}
