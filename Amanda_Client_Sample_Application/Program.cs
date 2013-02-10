using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Amanda.Client;

namespace Amanda_Client_Sample_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic client = new AmandaClient("http://localhost:15534/api");
            var res = client.SpliceUsers(new {ID = 1, Username = "shoopi", Password = "spliced"},
                                         new {ID = 2, Username = "whoopi", Password = "pass"});
            Console.WriteLine(res.ID);
            Console.WriteLine(res.Username);
            Console.WriteLine(res.Password);
        }
    }
}
