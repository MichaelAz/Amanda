using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using Amanda;

namespace WebTests
{
    public class TestHandlerService : AmandaModule
    {
        public TestHandlerService()
        {
            this.Exposes<TestHandler, AnotherTest>(TestHandler.Meth2Par)
                .WithBlakcList<TestHandler>("Str")
                .WithBlakcList<AnotherTest>("Num");
            this.Start();
        }

        public class TestHandler
        {
            public string Str { get; set; }

            public static void MethodWith2Param(TestHandler str, int num)
            {
                
            }

            public static void Meth2Par(TestHandler t, AnotherTest n)
            {
                
            }
        }

        public class AnotherTest
        {
            public int Num { get; set; }
        }
    }
}