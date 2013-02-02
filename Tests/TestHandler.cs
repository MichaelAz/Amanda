using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    public class TestHandler
    {
        public static bool MethodRan { get; set; }

        public static bool RetMethodRan { get; set; }

        public static void Method()
        {
            MethodRan = true;
        }
    }
}
