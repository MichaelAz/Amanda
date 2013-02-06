using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Amanda;

namespace WebTests
{
    public class TestHandlerService : AmandaModule
    {
        public TestHandlerService()
        {
            this.Exposes<string, int>(TestHandler.MethodWith2Param).WithVerb(Verb.Post);
            this.Start();
        }

        public class TestHandler
        {
            public static void MethodWith2Param(string str, int num)
            {
                
            }
        }
    }
}