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
            this.Exposes(TestHandler.Method).WithRoute("/NotTheDefault/RouteToMethod");
            this.Exposes(TestHandler.Method).WithVerb("Post");
            this.Start("/apy");
        }
    }
}