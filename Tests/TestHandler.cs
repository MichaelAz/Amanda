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

        public static void MethodWithParam(string hey)
        {
            
        }

        public static void MethodWith2Param(string hey, int num)
        {

        }

        public static void MethodWithComplexParam(ComplexClass c)
        {
            
        }

        public static void MethodWithMixedParams(string str, ComplexClass c)
        {
            
        }
    }

    public class ComplexClass   
    {
        public int Num { get; set; }

        public string Str { get; set; }

        public void ConWOP()
        {
            string t = Num + Str;
        }

        public void ConW1P(int num)
        {
            
        }

        public string ConW2P(int num, string str)
        {
            return num + str;
        }
    }
}
