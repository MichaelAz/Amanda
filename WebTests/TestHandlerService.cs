using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AmandaWS;
using Tests;

namespace WebTests
{
    public class TestHandlerService : Amanda
    {
        public TestHandlerService()
        {
            var s = new System.Web.Script.Serialization.JavaScriptSerializer();
            var ss = s.Serialize(new ComplexClass() {Num = 3, Str = "ShoopDaWhoop"});
            this.ExposesWithReturn<int, string, string>((new ComplexClass()).ConW2P);
            this.Start();
        }
    }
}