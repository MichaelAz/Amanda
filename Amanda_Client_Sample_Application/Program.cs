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
            // Initialize an AmandaClient pointing to an Amanda webservice located at a given uri
            dynamic client = new AmandaClient("http://localhost:15534/api");

            // To call a method through the API, just call it as you would locally
            client.DoNothing();

            // Methods that take complex parameters can be given anonymous types with
            // the correct properties
            var res = client.SpliceUsers(new {ID = 1, Username = "test", Password = "spliced"},
                                         new {ID = 2, Username = "test2", Password = "pass"});

            // Returned results are either a simple type like int or string or an ExpandoObject
            // if the returned type is complex
            Console.WriteLine(res.ID);
            Console.WriteLine(res.Username);
            Console.WriteLine(res.Password);
        }
    }
}
