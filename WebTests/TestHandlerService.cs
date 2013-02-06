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
            this.Exposes<TestHandler, int>(TestHandler.MethodWith2Param)
                .WithVerb(Verb.Post)
                .WithBlakcList<TestHandler>("Str");

            this.Exposes<TestHandler, int>(TestHandler.Meth2Par);

            this.Start();
        }

        public class TestHandler
        {
            public string Str { get; set; }

            public static void MethodWith2Param(TestHandler str, int num)
            {
                
            }

            public static void Meth2Par(TestHandler str, int num)
            {
                
            }
        }
    }
}